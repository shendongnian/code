    private static Timer _Timer;
    
    public static void Main()
    {
            // Create a timer with a 8 second interval.
            _Timer= new System.Timers.Timer(8000);
    
            // Hook up the Elapsed event for the timer. 
            _Timer.Elapsed += OnTimedEvent;
            _Timer.Enabled = true;
    
           // Start you other stuff here
     }
    
     private static void OnTimedEvent(Object source, ElapsedEventArgs e)
     {
            // Call your web service here
     }
