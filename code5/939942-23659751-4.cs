    void CreateTimer()
    {
        // Create an event to signal the timeout count threshold in the 
        // timer callback.
        AutoResetEvent autoEvent     = new AutoResetEvent(false);
        // Create an inferred delegate that invokes methods for the timer.
        TimerCallback tcb = CheckStatus;
        // Create a timer that signals the delegate to invoke  
        // CheckStatus after 15 minutes. 
        // thereafter.
        Console.WriteLine("{0} Creating timer.\n", DateTime.Now.ToString("h:mm:ss.fff"));
        System.Threading.Timer Timer stateTimer = new Timer(tcb, autoEvent, 1000 * 60 *15, 0);
        //Wait for 15 minutes
        autoEvent.WaitOne(1000 * 60 *15, false);
        stateTimer  = new Timer(tcb, null, 1000 * 60 *30, 0);
    }
    
    // This method is called by the timer delegate. 
    public void CheckStatus(Object stateInfo)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), stateInfo);
    }
    
    public void DoWork(Object stateInfo)
    {
        AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
        //Change your worktype here.
        CancellationTokenSource cts0 = new CancellationTokenSource();
        Class myClass1 = new Class();
        myClass1.CopyFiles(30, cts0.Token);
        autoEvent.Set();
    }
