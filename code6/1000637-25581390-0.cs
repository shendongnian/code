    Task UpdateAll(IEnumerable<Item> items)
    {
        var block = new ActionBlock<Item>(
            item => UpdateAsync(CreateUrl(item)), 
            new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 1000});
        
        foreach (var item in items)
        {
            block.Post(item);
        }
        block.Complete();
        return block.Completion;
    }
    
    async Task UpdateAsync(string url)
    {
        var response = await _client.SendAsync(url).ConfigureAwait(false);    
        Console.WriteLine(response.StatusCode);
    }
