        var aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
   
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        //update the label
    }
