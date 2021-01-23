     aTimer = new System.Timers.Timer(10000);
    
     // Hook up the Elapsed event for the timer.
     aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
     // Set the Interval to 2 seconds (2000 milliseconds).
     aTimer.Interval = 2000;
     aTimer.Enabled = true;
