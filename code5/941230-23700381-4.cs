    System.Timers.Timer MyTimer = new System.Timers.Timer();
    void UpdateMyTimer() //A one-time call to this function must be made.
    {
        MyTimer.Elapsed += new ElapsedEventHandler(MyTimer_Tick);
        MyTimer.Interval = 1000;
        MyTimer.Enabled = true;
    }
