    private static Timer m_oTimer;
    public static void Main ()
    {
        m_oTimer = new System.Timers.Timer ( 2 * 1000 * 60 ); // 2 minutes
        m_oTimer.Elapsed += OnTimedEvent; // Timer callback
        m_oTimer.Enabled = true; // Start timer
        // Wait here (you can do other processing here, too)
        Console.WriteLine ( "Press the Enter key to exit the program... " );
        Console.ReadLine ();
        Console.WriteLine ( "Terminating the application..." );
    }
    private static void OnTimedEvent ( Object source, ElapsedEventArgs e )
    {
        // This is called on a separate thread; do periodic processing here
        Console.WriteLine ( "The Elapsed event was raised at {0}", e.SignalTime );
    }
