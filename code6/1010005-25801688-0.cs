    static void Main()
    {
        // Create a timer with a one second interval.
        aTimer = new System.Timers.Timer(1000);
        
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += SendRequest;
        aTimer.Enabled = true;
    }
    
    private static void SendRequest(Object source, ElapsedEventArgs e)
    {
        // maybe end existing request if not completed?
        // send next request
    }
