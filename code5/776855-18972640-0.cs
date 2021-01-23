    private int progress = 0;
    private ManualResetEvent reset = new ManualResetEvent(false); 
    // Sets it to unsignalled
    private ManualResetEvent reset2 = new ManualResetEvent(false);
    
    while(progress  < 40)
    {
       progress ++;
    }
    
    reset.WaitOne();
    
    while(progress < 90)
    {
       progress ++;
    }
    
    reset2.WaitOne();
    
    while(progress < 100)
    {
       progress ++;
    }
