    // Create a 1 min timer 
        timer = new System.Timers.Timer(60000);
    
        // Hook up the Elapsed event for the timer.
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
        timer.Enabled = true;
    
    
    ...
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        MessageBox.Show("Hello World!");
        // Your code
    }
