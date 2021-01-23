    var inFinally = new ManualResetEvent(false);
    var abortCalled = new ManualResetEvent(false);
    var t = new Thread(_ =>
    {
        Console.WriteLine("Thread started..");
        try
        {
        }
        finally
        {
            inFinally.Set();
            abortCalled.WaitOne();
            Console.WriteLine(" ThreadState (before): " + Thread.CurrentThread.ThreadState);
            
            // This isn't thread safe, and ugly?
            if ((Thread.CurrentThread.ThreadState & ThreadState.AbortRequested) != 0)
            {
                Thread.ResetAbort();
            }
            
            Console.WriteLine(" ThreadState (after): " + Thread.CurrentThread.ThreadState);
        }
        Console.WriteLine("Executed because we called Thread.ResetAbort()");
    });
    t.Start();
    inFinally.WaitOne();
    // Call from another thread because Abort()
    // blocks while in finally block
    ThreadPool.QueueUserWorkItem(_ => t.Abort());
    while ((t.ThreadState & ThreadState.AbortRequested) == 0)
    {
        Thread.Sleep(1);
    }
    abortCalled.Set();
    Console.ReadLine();
    //  Output:
    //--------------------------------------------------
    // Thread started..
    //  ThreadState (before): AbortRequested
    //  ThreadState (after): Running
    // Executed because we called Thread.ResetAbort()
