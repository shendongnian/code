    public async Task QueryUrlsAsync()
    {
        var urlFetchingTasks = LIST_URL_COLLECTION.Select(url => Task.Run(url));
        await Task.WhenAll(urlFetchingTasks);
        Console.WriteLine("Done");
    }
