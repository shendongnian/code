    private static async Task<IEnumerable<string>> SomeAsyncMethod()
    {
    await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromMinutes(10)));
    return new List<string>();
    }
