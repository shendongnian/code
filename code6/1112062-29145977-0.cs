    protected override void OnStart(string[] args)
    {
        //This line does not block.
        Task.Run(() => RealStart());
    }
    
    private void RealStart()
    {
        Watchdog.Patrol(ConnectionString, new DealWatchdogService());
        timer = new Timer();
        //timer.Enabled = true; //Calling .Start() has the same effect.
        timer.Interval = 60000 * runMinInterval;
        timer.AutoReset = false;
        timer.Elapsed += timer_Elapsed;
        timer.Start(); //Start should be called after you have set .Elapsed
    }
