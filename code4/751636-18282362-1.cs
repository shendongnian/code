    public class Timer1
    {
        private static System.Timers.Timer aTimer;
    
        public static void Main()
        {
            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(600000);
    
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
            // Set the Interval to 10 minutes 
            aTimer.Interval = 600000;
            aTimer.Enabled = true;
    
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
    
            // If the timer is declared in a long-running method, use 
            // KeepAlive to prevent garbage collection from occurring 
            // before the method ends. 
            GC.KeepAlive(aTimer);
        }
    
        // Specify what you want to happen when the Elapsed event is  
        // raised. 
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Butnupdate.Enabled = false;
    	    MessageBox.Show("Time Up!");
        }
    }
