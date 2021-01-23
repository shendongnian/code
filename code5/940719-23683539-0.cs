    static System.Timers.Timer oTimer
    public static void Main()
    {
        oTimer = new System.Timers.Timer();
        oTimer.Elapsed += new ElapsedEventHandler(Handler);
        oTimer.Interval = 1000;
        oTimer.Enabled = true;                 
    }
    private void Handler(object oSource, ElapsedEventArgs oElapsedEventArgs)
    {
        oTimer.Enabled = false;
        Console.WriteLine("foo");
        Thread.Sleep(5000);         //simulate some work
        Console.WriteLine("bar");
        oTimer.Enabled = true;
    }
