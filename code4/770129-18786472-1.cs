    private void InitService()
    {
        //starts immediately, interval is in TimeSpan 
        this._oTimer = new System.Threading.Timer(
            OnTimeout,
            null, 
            TimeSpan.Zero,
            TimeSpan.FromMinutes(10)
        );
    }
    protected override void OnStart(string[] args)
    {
        InitService();
    }
    protected override void OnStop()
    {
        this._oTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
    }
    private void ImportTimer_Elapsed(Object state)
    {
        DoSomeDatabaseStuff();
    }
