    async Task<IEnumerable<string>> GetAllStringsAsync(IEnumerable<string> urls)
    {
        var client = new HttpClient();
        var bag = new ConcurrentBag<string>();
        var block = new ActionBlock<string>(
            async url => bag.Add(await client.GetStringAsync(url)),
            new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 5});
        foreach (var url in urls)
        {
            block.Post(url);
        }
        block.Complete();
        await block.Completion;
        return bag;
    }
