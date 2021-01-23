    private void DoIt()
    {
        // Timeout.Infinite makes it a one-shot timer
        _myTimer = new Timer(MyTimerCallback, null, 1000, Timeout.Infinite);
        // other code
    }
    private void MyTimerCallback(object state)
    {
        // do whatever processing is necessary
        // and then restart the timer
        _myTimer.Change(1000, Timeout.Infinite);
    }
