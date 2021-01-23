    ManualResetEventSlim _mre = new ManualResetEventSlim(false);
    public string WaitForIdleAndGetErrors()
    {
        if (queue.IsCompleted == false )
        {
           _mre.Wait();
        }
       return ErrorsOccurred;
    }
