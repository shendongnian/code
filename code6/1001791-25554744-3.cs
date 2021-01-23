    public async Task<IHttpActionResult> Post(string value)
    {
        var results = await PerformWebRequests();
        // Do something else here...
    }
    private async Task<IEnumerable<string>> PerformWebRequests()
    {
        var result1 = await PerformWebRequestAsync("service1/api/foo");
        var result = await PerformWebRequestAsync("service2/api/foo");
        return new string[] { result1, result2 };
    }
    private async string PerformWebRequestAsync(string api)
    {
        using (HttpClient client = new HttpClient())
        {
            await client.GetAsync(api);
        }
        // More work..
    }
