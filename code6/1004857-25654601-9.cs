    public static Task Run(SemaphoreSlim sem)
    {
        TraceThreadCount();
        return sem.WaitAsync().ContinueWith(t =>
        {
            TraceThreadCount();
            sem.Release();
        }, TaskContinuationOptions.ExecuteSynchronously);
    }
