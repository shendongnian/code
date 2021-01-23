    public void ProcessLogicBuffer()
    {
        var timer = new System.Threading.Timer(MyTimerProc, null, 200, 200);
        // queue processing stuff here
        // Just to make sure that the timer isn't garbage collected. . .
        GC.KeepAlive(timer);
    }
    private void MyTimerProc(object state)
    {
        // do periodic processing here
    }
