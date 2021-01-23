    public async Task<IList<T>> Query<T>(string query)
    {
        var response = await _serviceHttpClient.HttpGet<T>(string.Format("query?q={0}", query), "records");
        return response;
    }
    
    public async Task<IList<T>> HttpGet<T>(string urlSuffix, string nodeName)
    {
        var list = new List<T>();
        do
        {
            var r = await HttpGetInternal<T>(urlSuffix, nodeName);
    
            list.Add(r.Records);
        }
        while (!string.IsNullOrEmpty(r.NextRecordsUrl));
    
        return list;
    }
