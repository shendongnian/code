    void SumFun()
    {
        aTimer = new System.Timers.Timer(10000);        
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 2000;
        aTimer.Enabled = true;
    }    
