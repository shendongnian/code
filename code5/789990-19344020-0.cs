    await WorkerMainAsync();
    
    async Task WorkerMainAsync()
    {
      SemaphoreSlim ss = new SemaphoreSlim(10);
      while (true)
      {
        await ss.WaitAsync();
        // you should probably store this task somewhere and then await it
        var task = DoPollingThenWorkAsync();
      }
    }
    
    async Task DoPollingThenWorkAsync(SemaphoreSlim semaphore)
    {
      var msg = Poll();
      if (msg != null)
      {
        await Task.Delay(3000); // process the I/O-bound job
      }
    
      // this assumes you don't have to worry about exceptions
      // otherwise consider try-finally
      semaphore.Release();
    }
