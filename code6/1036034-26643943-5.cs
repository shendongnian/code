    public void ProcessLogicBuffer()
    {
        var timer = new System.Timers.Timer(MyTimerProc, null, 200, 200);
        // queue processing stuff here
    }
    private void MyTimerProc(object state)
    {
        // do periodic processing here
    }
