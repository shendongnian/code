        class Updater
        {
            Timer timer = new Timer();
            public object StateLock = new object();
            public string State;
    
            public Updater()
            {
                timer.Elapsed += timer_Elapsed;
                timer.Interval = 10000;
                timer.AutoReset = true;
                timer.Start();
            }
    
            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (State != "Running")
                {
                    Process();
                }
            }
    
            private void Process()
            {
                try
                {
                    lock (StateLock)
                    {
                        State = "Running";
                    }
    
                    // Process
    
                    lock (StateLock)
                    {
                        State = "";
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
...
    class Program
    {
        static void Main(string[] args)
        {
            Updater updater = new Updater();
            Console.ReadLine();
        }
    }
