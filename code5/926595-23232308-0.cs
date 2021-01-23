    System.Threading.Timer myTimer = 
        new System.Threading.Timer(MyTimerProc, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
    void MyTimerProc(object state)
    {
        // do something here
    }
