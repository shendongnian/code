    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(URI);
    
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("api_key", token);
    
        var content = new ObjectContent(syncString, new JsonMediaTypeFormatter());
    
        var result = client.PostAsync("/api/Food/", content).Result;
    }
