    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri)
                { Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json") });
    }
