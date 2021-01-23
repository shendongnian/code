    private System.Timers.Timer serviceTimer;
    protected override void OnStart(string[] args)
    {
        serviceTimer = new System.Timers.Timer();
        serviceTimer.Interval = 3600000; //one hour
        serviceTimer.Elapsed += serviceTimer_Elapsed;
        serviceTimer.Enabled = true;
    }
    void serviceTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        serviceTimer.Enabled = false;
        // do your process
        serviceTimer.Enabled = true;
    }
