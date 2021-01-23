    var client = new HttpClient(new WebRequestHandler() {
        CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore)
    });
            try
        {
            string responseBody = await client.GetStringAsync("http://www.lipsum.com");
            ParseHTML(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
