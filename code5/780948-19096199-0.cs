    static void Main()
    {
        Console.WriteLine("start");
        var innerCts = new CancellationTokenSource();
        Exception mainException = null;
        var mainThread = new Thread(() => SafeMainThread(innerCts, ref mainException));
        mainThread.Start();
        var innerTask = Task.Factory.StartNew(state => PrintTime(state),
                                              innerCts,
                                              innerCts.Token,
                                              TaskCreationOptions.LongRunning,
                                              TaskScheduler.Default);
        var innerFault = innerTask.ContinueWith(t => { Console.WriteLine("Inner thread caused " + t.Exception.InnerException.GetType().Name + ". Main thread is being aborted..."); mainThread.Abort(); },
                                                TaskContinuationOptions.OnlyOnFaulted);
        var innerCancelled = innerTask.ContinueWith(_ => Console.WriteLine("Inner thread cancelled."),
                                                    TaskContinuationOptions.OnlyOnCanceled);
        var innerSucceed = innerTask.ContinueWith(_ => Console.WriteLine("Inner thread completed."),
                                                  TaskContinuationOptions.OnlyOnRanToCompletion);
        try
        {
            innerTask.Wait();
        }
        catch (AggregateException)
        {
            // Ignore.
        }
        mainThread.Join();
        Console.ReadLine();
    }
    private static void SafeMainThread(CancellationTokenSource innerCts, ref Exception mainException)
    {
        try
        {
            MainThread();
            Console.WriteLine("Main thread completed.");
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Main thread aborted.");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Main thread caused " + exception.GetType().Name + ". Inner task is being canceled...");
            innerCts.Cancel();
            mainException = exception;
        }
    }
    private static void MainThread()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("master thread i={0}", i + 1);
            Thread.Sleep(500);
        }
        throw new Exception("exception");
    }
    private static void PrintTime(object state)
    {
        var cts = (CancellationTokenSource)state;
        for (int i = 0; i < 10; i++)
        {
            cts.Token.ThrowIfCancellationRequested();
            Console.WriteLine("inner thread i={0}", i + 1);
            Thread.Sleep(500);
        }
        throw new Exception("exception");
    }
