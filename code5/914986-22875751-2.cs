    const int MAX_PARALLEL_TASKS = 4;
    
    DbDataReader GetData(CancellationToken token)
    {
        DbDataReader reader = ... // execute the synchronous DB API
        return reader;
    }
    
    // this can be called form an async controller method
    async Task ProcessAsync()
    {
        // list of synchronous methods or lambdas to offload to thread pool
        var funcs = new Func<CancellationToken, DbDataReader>[] { 
            GetData, GetData2, ...  };
    
        Task<DbDataReader>[] tasks;
        using (var semaphore = new SemaphoreSlim(MAX_PARALLEL_TASKS))
        {
            tasks = funcs.Select(async(func) => 
            {
                await semaphore.WaitAsync();
                try
                {
                    return await Task.Run(() => func(token));
                }
                finally
                {
                    semaphore.Release();
                }
            }).ToArray();
    
            await Task.WhenAll(tasks);
        }
        // process the results, e.g: tasks[0].Result
    }
