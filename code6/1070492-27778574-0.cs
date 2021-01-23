     public static void Main()
       {
            // Create a timer with 30 seconds interval.
            aTimer = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
       }
    
