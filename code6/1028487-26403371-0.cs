    public class Example
    {
        private static Timer aTimer;
        public static void Main()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program... ");
            Console.ReadLine();
            Console.WriteLine("Terminating the application...");
        }
        public static void DoWork()
        {
            var workCounter = 0;
            while (workCounter < 100)
            {
                Console.WriteLine("Alpha.Beta is running in its own thread." + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                workCounter++;
            }
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Create the thread object, passing in the method
            // via a delegate.
            var oThread = new Thread(DoWork);
            // Start the thread
            oThread.Start();
        }
    }
