    public static async Task ForEachAsync<T>(
        this IEnumerable<T> items, Func<T, Task> action, int maxDegreeOfParallelism)
    {
        var semaphore = new SemaphoreSlim(maxDegreeOfParallelism);
        var tasks = new List<Task>();
        foreach (var item in items)
        {
            await semaphore.WaitAsync();
            Func<T, Task> loopAction = async x =>
            {
                await action(x);
                semaphore.Release();
            };
            tasks.Add(loopAction(item));
        }
        await Task.WhenAll(tasks);
    }
