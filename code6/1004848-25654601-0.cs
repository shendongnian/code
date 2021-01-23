    public static async Task RunAsync(SemaphoreSlim sem)
    {
        TraceThreadCount();
        await Task.Delay(1000);
        await sem.WaitAsync();
        TraceThreadCount();
        sem.Release();
    }
