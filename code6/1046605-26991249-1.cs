    public async bool CallMethod()
    {
        var rootUrl = "http:...";
        bool result;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_rootUrl);
            var response= await client.PostAsJsonAsync(methodUrl, new {n = 10, s = "some string"}); 
            result = await response.Content.ReadAsAsync<bool>();
        }
        
        return result;
    }
