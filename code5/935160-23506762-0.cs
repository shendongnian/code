    private static System.Timers.Timer timer;
    
    private void Form1_Load(object sender, System.EventArgs e)
    {
        timer = new System.Timers.Timer(); // Create a new timer instance
        timer.Elapsed += new ElapsedEventHandler(Button1_Click); // Hook up the Elapsed event for the timer.
        timer.AutoReset = true; // Instruct the timer to restart every time the Elapsed event has been called                
        timer.SynchronizingObject = this; // Synchronize the timer with this form UI (IMPORTANT)
    	timer.Interval = 1000; // Set the interval to 1 second (1000 milliseconds)
    	timer.Enabled = true; // Start the timer
    }
