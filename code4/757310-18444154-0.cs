    System.Threading.Timer _timeoutTimer;
    //...
    int timeout = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
    _timeoutTimer = new System.Threading.Timer(OnTimerElapsed, 
        null, timeout, System.Threading.Timeout.Infinite);
    //...
    void OnTimerElapsed(object state) {
         // do something
        _timeoutTimer.Dispose();
    }
