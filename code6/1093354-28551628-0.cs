    using (HttpClient httpClient = new HttpClient())
    {
        var response = httpClient.GetAsync(_endpoint).GetAwaiter().GetResult();
        var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        // Do stuff...
    }
