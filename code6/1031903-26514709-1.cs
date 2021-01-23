    private readonly object _lockObj = new object();
    public void StartThread()
    {
        new Thread(ThreadProc).Start();
    }
    public void SignalThread()
    {
        lock (_lockObj)
        {
            // Initialize some data that the thread will use here...
            // Then signal the thread
            Monitor.Pulse(_lockObj);
        }
    }
    private void ThreadProc()
    {
        lock (_lockObj)
        {
            // Wait for the signal
            Monitor.Wait(_lockObj);
            // Here, use data initialized by the other thread
        }
    }
