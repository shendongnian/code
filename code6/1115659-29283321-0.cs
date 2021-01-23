    // Start OWIN host 
    using (WebApp.Start<Startup>(url: baseAddress))
    {
        var handler = new HttpClientHandler
        {
            UseDefaultCredentials = true
        };
        using (var client = new HttpClient(handler))
        {
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.GetAsync("/api/Values");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<string>>();
            Assert.Equal(2, result.Count);
        }
    }
