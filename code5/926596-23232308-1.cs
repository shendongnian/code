    System.Threading.Timer myOtherTimer = 
        new System.Threading.Timer(MyOtherTimerProc, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
    void MyOtherTimerProc(object state)
    {
        // do something else here
    }
