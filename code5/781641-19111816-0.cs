    SemaphoreSlim slotsSemaphore = new SemaphoreSlim(…);
    
    …
    
    foreach (var job in JobQueue.GetConsumingEnumerable())
    {
        slotsSemaphore.Wait();
    
        JobHandler jobHandler = job;
    
        Task.Factory.StartNew(() =>
        {
            try
            {
                ExecuteJob(jobHandler);
            }
            finally
            {
                slotsSemaphore.Release();
            }
        });
    }
