    using (var scheduler = new StaTaskScheduler(numberOfThreads: 1))
    {
        await Task.Factory.StartNew(
            () => mutex.WaitOne(), 
            CancellationToken.None,
            TaskCreationOptions.None,
            scheduler);
        try
        {
            // use the shared resource on the UI thread
        }
        finally
        {
            Task.Factory.StartNew(
                () => mutex.Release(), 
                CancellationToken.None,
                TaskCreationOptions.None,
                scheduler).Wait();
        }
    }
