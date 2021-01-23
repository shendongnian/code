    using System.Threading;
    ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
    ManualResetEvent _processEvent  = new ManualResetEvent(false);
    Thread _thread;
    protected override void OnStart(string[] args)
    {
        // Create the formal, foreground thread.
        _thread = new Thread(Execute);
        _thread.IsBackground = false;  // set to foreground thread
        _thread.Start();
        // Start the timer.  Notice the lambda expression for setting the
        // process event when the timer elapses.
        int intDelai = Properties.Settings.Default.WatchDelay * 1000;
        _oTimer = new System.Timers.Timer(intDelai);
        _oTimer.AutoReset = false;
        _oTimer.Elapsed += (sender, e) => _processEvent.Set();
        _oTimer.Start();
    }
