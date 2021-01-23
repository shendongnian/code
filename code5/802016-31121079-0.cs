    SemaphoreSlim semaphore = new SemaphoreSlim(2);
    
    async void Reader1()
    {
        await semaphore.WaitAsync();
        try
        {
            // ... reading stuff ...
        }
        finally
        {
            semaphore.Release();
        }
    }
    async void Reader2()
    {
        await semaphore.WaitAsync();
        try
        {
            // ... reading other stuff ...
        }
        finally
        {
            semaphore.Release();
        }
    }
    async void ExclusiveWriter()
    {
        // the exclusive writer must request all locks
        // to make sure the readers don't have any of them
        // (I wish we could specify the number of locks
        // instead of spamming multiple calls!)
        await semaphore.WaitAsync();
        await semaphore.WaitAsync();
        try
        {
            // ... writing stuff ...
        }
        finally
        {
            // release all locks here
            semaphore.Release(2);
            // (oh here we don't need multiple calls, how about that)
        }
    }
