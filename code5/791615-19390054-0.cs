    using (HttpClient client = new HttpClient())
    using (HttpResponseMessage response = await client.GetAsync(url))
    using (HttpContent content = response.Content)
    {
        
        string result = await content.ReadAsStringAsync();
    
        
    }
