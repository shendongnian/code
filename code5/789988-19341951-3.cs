    async Task WorkerMainAsync()
    {
      SemaphoreSlim ss = new SemaphoreSlim(10);
      List<Task> trackedTasks = new List<Task>();
      while (DoMore())
      {
        await ss.WaitAsync();
        trackedTasks.Add(Task.Run(() => 
                  {
                    DoPollingThenWorkAsync();
                    ss.Release();
                  }));
      }
      await Task.WhenAll(trackedTasks);
    }
    
    void DoPollingThenWorkAsync()
    {
      var msg = Poll();
      if (msg != null)
      {
        Thread.Sleep(2000); // process the long running CPU-bound job
      }
    }
