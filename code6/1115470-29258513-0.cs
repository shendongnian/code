    public Task<HttpResponseMessage> InvokeApiAsync(
    	string apiName,
    	HttpContent content,
    	HttpMethod method,
    	IDictionary<string, string> requestHeaders,
    	IDictionary<string, string> parameters
    )
