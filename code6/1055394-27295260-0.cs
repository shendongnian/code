    private System.Timers.Timer myTimer;
    protected override void OnStart(string[] args)
    {
        myTimer = new Timer(5000);          // Every 5 seconds
        myTimer.AutoReset = false;          // Only 1 event!!
        myTimer.Elapsed += TimerElapsed;    // Event handler
        myTimer.Start();                    // Start the timer
    }
    protected override void OnStop()
    {
        myTimer.Stop();
        myTimer = null;
    }
    privated void TimerElapsed(object source, ElapsedEventArgs e)
    {
        try
        {
            // Do stuff
        }
        finally
        {
            // Restart if timer variable is not null
            if (myTimer != null)        
                myTimer.Start();
        }
    }
