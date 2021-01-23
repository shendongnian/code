    public async Task<IEnumerable<HttpResponseMessage>> GetStuffs(IEnumerable<string> uris)
    {
        var tasks = new List<Task<HttpResponseMessage>>();
        var client = new HttpClient();
            
        foreach (var uri in uris)
        {
            var task = client.GetAsync(uri);
            tasks.Add(task);
        }
        Task.WaitAll(tasks.ToArray());
        return tasks.Select(x => x.Result);
    }
