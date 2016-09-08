﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://taskmodel.azurewebsites.net/api/TaskModels/";
        //private const string WebServiceUrl = "http://oziel.com/Pizzaria/api/services/";
        private const string UrlServices = "http://oziel.com/Pizzaria/api/services/";
        private static readonly string UrlListaProdutos = string.Format("{0}GetProdutos/1", WebServiceUrl);

        public async Task<List<T>> GetProductsAsync()
        {
            var request = WebRequest.Create("http://oziel.com/Pizzaria/api/services/GetProdutos/7");

            var httpClient = new HttpClient { BaseAddress = request.RequestUri };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var ssss = await httpClient.GetAsync(request.RequestUri);


            //var json = await httpClient.GetStringAsync(WebServiceUrl);

            //var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            //return taskModels;
            return new List<T>();
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}