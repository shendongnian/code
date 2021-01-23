    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting timer");             
            var timer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer.
            timer.Elapsed += OnTimer;;
            timer.Enabled = true;
            Console.WriteLine("Press any key to shut down");
            Console.ReadKey();
        }
        static void OnTimer(object source, ElapsedEventArgs e)
        {
            // This code will run every 10 seconds
            Console.WriteLine("In timer");
        }
    }
