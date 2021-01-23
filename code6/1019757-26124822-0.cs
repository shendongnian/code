    public async Task<Dictionary<string, object>> Read(IEnumerable<string> queries)
    {
        var tasks = new Dictionary<string, Task<object>>();
        foreach(string query in queries)
            tasks.Add(query, LoadDataAsync(query));
        await Task.WhenAll(tasks.Values);
        return tasks.ToDictionary(x=>x.Key, x.Value.Result);
    }
        
