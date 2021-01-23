    private static CancellationTokenSource _cancellationTokenSource =
        new CancellationTokenSource();
    static void Main(string[] args)
    {
        Task longRunning = Task.Factory.StartNew(Go, TaskCreationOptions.LongRunning);
        while (true)
        {
            // Pass _cancellationTokenSource.Token to worker items to support
            // cancelling the operation(s) immediately if the long running
            // operation throws an exception
            Thread.Sleep(1000);
            // this will throw an exception if the task faulted, or simply continue
            // if the task is still running
            longRunning.Wait(0);
        }
    }
    private static void Go()
    {
        try
        {
            Thread.Sleep(4000);
            throw new Exception("Oh noes!!");
        }
        catch
        {
            _cancellationTokenSource.Cancel();
            throw;
        }
    }
