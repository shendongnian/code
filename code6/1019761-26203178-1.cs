    public async Task<KeyValuePair<string, object>> LoadNamedResultAsync(string query)
    {
        Task<object> getLoadDataTask = await LoadDataAsync(query);
        return new KeyValuePair<string, object>(query, getLoadDataTask.Result);
    }
    public async Task<IDictionary<string, object>> Read(string[] queries)
    {
        var tasks = queries.Select(LoadNamedResultAsync);
        var results = await Task.WhenAll(tasks);
        return results.ToDictionary(r => r.Key, r => r.Value);
    }
