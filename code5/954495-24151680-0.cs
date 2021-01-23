    protected override void OnStartup(StartupEventArgs e)
    {
        _sysEventCollector = new SystemEventCollector();
         _sysEventCollector.SessionEvent += OnSessionEvent;
    }
