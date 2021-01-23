    var httpClient = new HttpClient();
    // This will process async
    var results = await httpClient.GetAsync("http://example.com");
    // This will process async
    var stream = await results.Content.ReadAsStreamAsync();
    using (var sr = new StreamReader(stream))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            // add line and do something else
        }
    }
