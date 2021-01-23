    public static Task ForEachAsync<T>(
        this IEnumerable<T> items, Func<T, Task> action, int maxDegreeOfParallelism)
    {
        var block = new ActionBlock<T>(
            action,
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism
            });
        foreach (var item in items)
        {
            block.Post(item);
        }
        block.Complete();
        return block.Completion;
    }
