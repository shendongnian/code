    static void Test(CancellationToken token)
    {
        Callback callback = new Callback();
        try
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                // for the GC
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                Thread.Sleep(100);
            }
        }
        finally
        {
            GC.KeepAlive(callback);		
        }
    }
