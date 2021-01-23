    async static Task TestAsync()
    {
        Func<Task> doAsync = async () =>
        {
            await Task.Delay(1).ConfigureAwait(false);
            Console.WriteLine(new { Thread.CurrentThread.ManagedThreadId });
        };
        var tasks = Enumerable.Range(0, 10).Select(i => doAsync());
        await Task.WhenAll(tasks);
    }
    // ...
    TestAsync().Wait();
