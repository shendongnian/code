    interface IHttpClient
    {
        HttpResponseMessage Get(string uri);
    }
    class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _client;
        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
        }
        public HttpResponseMessage Get(string uri)
        {
            return _client.GetAsync(new Uri(uri)).Result;
        }
    }
