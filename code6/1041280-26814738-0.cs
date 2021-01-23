    public void start()
    {
           
     // Create a timer with a two minutes interval.
        aTimer = new System.Timers.Timer(120000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
        
     }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
       aTimer.Enabled = false;
    // do what you want .........
    }
