    private readonly ConcurrentDictionary<HttpRequestInfo, HttpClient> _httpClients;
    
    private HttpClient GetHttpClient(HttpRequestInfo httpRequestInfo)
    {
        if (_httpClients.ContainsKey(httpRequestInfo))
        {
            HttpClient value;
            if (!_httpClients.TryGetValue(httpRequestInfo, out value))
            {
                throw new InvalidOperationException("It seems there is no related http client in the dictionary.");
            }
    
            return value;
        }
    
        var httpClient = new HttpClient { BaseAddress = new Uri(httpRequestInfo.BaseUrl) };
        if (httpRequestInfo.RequestHeaders.Any())
        {
            foreach (var requestHeader in httpRequestInfo.RequestHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(requestHeader.Key, requestHeader.Value);
            }
        }
    
        httpClient.DefaultRequestHeaders.ExpectContinue = false;
        httpClient.DefaultRequestHeaders.ConnectionClose = true;
        httpClient.Timeout = TimeSpan.FromMinutes(2);
        if (!_httpClients.TryAdd(httpRequestInfo, httpClient))
        {
            throw new InvalidOperationException("Adding new http client thrown an exception.");
        }
    
        return httpClient;
    }
