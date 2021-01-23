    private Timer _systemTimer = null;
    public MyApp()
    {
    _systemTimer = new Timer("how ever you set your 1 second);
    // Create your event handler for when it ticks over
    _systemTimer.Elapsed += new ElapsedEventHandler(systemTimerElapsed);
    }
    protected void systemTimerElapsed(object sender, ElapsedEventArgs e)
    {
    _systemTimer.Stop();
    //Do what you need to do
    _systemTimer.Start();
    //This way if it takes longer than a second it won't matter, another time won't kick off until the previous job is done 
    }
