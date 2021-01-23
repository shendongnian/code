    public async Task QueryUrlsAsync()
    {
        var urlFetchingTasks = ListUrlCollection.Select(url => Task.Run(url));
        await Task.WhenAll(urlFetchingTasks);
        Console.WriteLine("Done");
    }
