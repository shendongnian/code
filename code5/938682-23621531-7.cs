    public Task<Task<string>[]> DoIt()
    {
        var urls = new string[] { "http://www.msn.com", "http://www.google.com" };
        var tasks = urls.Select(x => this.GetUrlContents(x)).ToArray();
        return Task.Factory.ContinueWhenAll(
            tasks, 
            _ => tasks, 
            CancellationToken.None, 
            TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    }
