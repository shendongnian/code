    public void initilize_Rfid()
    {
        _timerComm = new System.Timers.Timer(500);
        _timerComm.Elapsed += CommTimerEvent;
        _timerComm.Enabled = true;
        _timerComm.Start();
    }
