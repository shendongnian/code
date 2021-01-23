    static void Main()
    {
        try
        {
            Run().Wait();
        }
        catch (AggregateException aex)
        { }
    }
    static async Task Run()
    {
        Task[] tasks = new[] { CreateTask("ex1"), CreateTask("ex2") };
        var compositeTask = Task.WhenAll(tasks);
        await compositeTask.ContinueWith((antecedant) => { }, TaskContinuationOptions.ExecuteSynchronously);
    }
    static Task CreateTask(string message)
    {
        return Task.Factory.StartNew(() => { throw new Exception(message); });
    }
