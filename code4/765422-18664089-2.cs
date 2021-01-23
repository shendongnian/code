        static void Main()
        {
            // Define timer
            System.Timers.Timer t = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 1000
            };
            // Give timer the tick function
            t.Elapsed += (object tSender, System.Timers.ElapsedEventArgs tE) =>
            {
                Console.WriteLine("Done!");
            };
            
            Console.ReadLine();
        }
