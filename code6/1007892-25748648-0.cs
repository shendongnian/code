    private static Timer aTimer;
    private static ManualResetEventSlim ev = new ManualResetEventSlim(false);
    public static void Main()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(5000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
        ev.Wait();
    }
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        ev.Set();
    }
