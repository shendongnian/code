    private System.Timers.Timer timerClock = new System.Timers.Timer();    
    timerClock.Elapsed += new ElapsedEventHandler(OnTimer);
    timerClock.Interval = 1000;
    timerClock.Enabled = true;
    
    public void OnTimer( Object source, ElapsedEventArgs e )
    {
        foreach (var item in SerialPort.GetPortNames())
            {
                if (item == "COM3")
                {
                    boardjoined = true;
                    DisplayImage(_pic_usb, "on.png");
                }
                else
                {
                    boardjoined = false;
                    DisplayImage(_pic_usb, "off.png");
                }
            } 
    }
