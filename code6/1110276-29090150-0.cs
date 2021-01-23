    private void Reconnect()
    {
        timeOut = false;
        new System.Threading.Thread(new System.Threading.ThreadStart(setTimeout)).Start();
        rdp1.Disconnect(); 
        while (rdp1.Connected == 1 && !timeOut);
        rdp1.Connect();
    }
    bool timeOut = false;
    void setTimeout()
    {
        System.Threading.Thread.Sleep(7000);
        timeOut = true;
    }
