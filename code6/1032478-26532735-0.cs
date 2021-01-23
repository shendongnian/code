    public async IQueryable<ClientAddressResult> GetClientAddress()
    {
        WebRequest request = WebRequest.CreateHttp("http://callme/address.ashx");
    
        var response = await request.GetResponseAsync();
        string content;
    
        using (var stream = response.GetResponseStream())
        using(var reader = new StreamReader(stream))
        {
            content = await reader.ReadToEndAsync();
        }
    
        IEnumerable<MyResult> result = JsonConvert.DeserializeObject<MyResult[]>(content);
    
        return result.Select(r => new ClientAddressResult{Address = r.ClientAddress})
            .AsQueryable();
    }
