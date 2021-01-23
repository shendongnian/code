    static SemaphoreSlim sem = new SemaphoreSlim(maxDegreeOfParallelism); //shared object
    async Task MyWorkerFunction()
    {
        await sem.WaitAsync();
        try
        {
            MyWork();
        }
        finally
        {
            sem.Release();
        }
    }
