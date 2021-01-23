    var mre = new ManualResetEvent(initialState: false);
    EventHandler<UnobservedTaskExceptionEventArgs> subscription = (s, args) => mre.Set();
    TaskScheduler.UnobservedTaskException += subscription;
    try
    {
        var res = Task.Run(() =>
        {
            throw new NotImplementedException();
            return new DateTime?();
        });
        ((IAsyncResult)res).AsyncWaitHandle.WaitOne(); // Wait for the task to complete
        res = null; // Allow the task to be GC'ed
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (!mre.WaitOne(10000))
            Assert.Fail();
    }
    finally
    {
        TaskScheduler.UnobservedTaskException -= subscription;
    }
