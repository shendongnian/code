    static int Main()
    {
       System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
       myTimer.Tick += new EventHandler(TimerTick);
       //timer tick inteval in ms
       myTimer.Interval = 5000;
       myTimer.Start();
    }
    static void TimerTick(object obj, EventArgs e)
    {
       //do Logic here
    }
