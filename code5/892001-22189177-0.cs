    int _asyncCalls = 0;
    Constructor()
    {
       startprogressindicator();
    
       Interlocked.Increment(ref _asyncCalls);
       try
       {
           // better yet, do Interlocked.Increment(ref _asyncCalls) inside
           // each callasyncN
         
           Interlocked.Increment(ref _asyncCalls);
           callasync1(finished1);
           Interlocked.Increment(ref _asyncCalls);
           callasync2(finished2);
           //.... and so on
       }
       finally
       {       
           checkStopProgreessIndicator();
       }
    }
    public checkStopProgreessIndicator()
    {
       if (Interlocked.Decrement(ref _asyncCalls) == 0)
           stopprogressindicator();
    }
    
    public void finished1()
    {
        checkStopProgreessIndicator()
    }
    
    public void finished2()
    {
        checkStopProgreessIndicator()
    }
