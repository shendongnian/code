    SemaphoreSlim _semaphore = new SemaphoreSlim(20);
    
    async Task DoSomethingAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            // possibly async operations limited to 20
        }
        finally
        {
            _semaphore.Release();
        }
    }
