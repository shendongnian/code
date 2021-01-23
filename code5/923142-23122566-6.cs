    await Task.Factory.StartNew(() => 
    {
        mutex.WaitOne();
        try
        {
            // use the shared resource
        }
        finally
        {
            mutex.ReleaseMutex(); 
        }
    }, TaskCreationOptions.LongRunnning);
