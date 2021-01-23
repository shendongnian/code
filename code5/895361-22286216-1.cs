    private static System.Timers.Timer myTimer;
    public static void Main()
    {
        myTimer = new System.Timers.Timer(60000);  // 60 seconds
        myTimer.Elapsed += new ElapsedEventHandler(DisableButtons); // subscribe
        myTimer.AutoReset = false; // if you don't want a reset
        myTimer.Enabled = true;    // enable it
    }
    // perform when event is fired off
    private static void DisableButtons(object source, ElapsedEventArgs e)
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        button4.Enbaled = false;
    }
