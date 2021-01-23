    private static async Task<SearchItem[]> GetSearchItemsAsync()
    {
        var task1 = _client.DoSearchSimpleAsync("query1", "subQuery1");
        var task2 = _client.DoSearchSimpleAsync("query2", "subQuery2");
        var task3 = _client.DoSearchSimpleAsync("query3", "subQuery3");
        var results = await Task.WhenAll(task1, task2, task3);
        var list = new List<SearchItem>();
        list.AddRange(results[0]);
        list.AddRange(results[1]);
        list.AddRange(results[2]);
        return list;
    }
