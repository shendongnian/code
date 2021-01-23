    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    myTimer.Tick += DisplayTimeEvent;
    myTimer.Interval = 1000; // 1000 ms is one second
    myTimer.Start();
    public static void DisplayTimeEvent(object source, EventArgs e)
    {
       // code here will run every second
    }
