    public async Task<HttpResponseMessage> Post(
        string methodName, HttpRequestMessage request)
    {
        HttpResponseMessage response;
        switch (methodName)
        {
            case "brownie":
                response = await HandleBrownieAsync(request);
                break;
            case "pizza":
                response = await HandlePizzaAsync(request);
                break;
            default:
                throw new NotSupportedException();
        }
        return response;
    }
    
    private async Task<HttpResponseMessage> HandleBrownieAsync(HttpRequestMessage request)
    {
        var brownie = await GetRequestContentAsync<Brownie>(request);
        return await CreateJsonResponseAsync(brownie);
    }
    
    private async Task<HttpResponseMessage> HandlePizzaAsync(HttpRequestMessage request)
    {
        var pizza = await GetRequestContentAsync<Pizza>(request);
        return await CreateJsonResponseAsync(pizza);
    }
    
    private async Task<T> GetRequestContentAsync<T>(HttpRequestMessage request)
    {
        var contentString = await request.Content.ReadAsStringAsync();
        return await JsonConvert.DeserializeObjectAsync<T>(contentString);
    }
    
    private async Task<HttpResponseMessage> CreateJsonResponseAsync<T>(T content)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                await JsonConvert.SerializeObjectAsync(content),
                Encoding.UTF8,
                "application/json")
        };
        return response;
    } 
