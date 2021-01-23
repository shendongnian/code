    void CreateTimer()
    {
        // Create an inferred delegate that invokes methods for the timer.
        TimerCallback tcb = statusChecker.CheckStatus;
        // Create a timer that signals the delegate to invoke  
        // CheckStatus after thirty minutes, and every 1 minute 
        // thereafter.
        Console.WriteLine("{0} Creating timer.\n", DateTime.Now.ToString("h:mm:ss.fff"));
        System.Threading.Timer Timer stateTimer = new Timer(tcb, null, 1000 * 60 *30, 1000*60);
     }
    // This method is called by the timer delegate. 
        public void CheckStatus(Object stateInfo)
        {
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), null);
        }
    
    public void DoWork()
    {
      CancellationTokenSource cts0 = new CancellationTokenSource();
      Class myClass1 = new Class();
      myClass1.CopyFiles(30, cts0.Token);
    }
