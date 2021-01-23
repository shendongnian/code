    public async Task QueryUrlsAsync()
    {
        var urlFetchingTasks = ListUrlCollection.Select(url => 
                               {
                                   var httpClient = new HttpClient();
                                   return httpClient.GetAsync(url);
                               });
        await Task.WhenAll(urlFetchingTasks);
        Console.WriteLine("Done");
    }
