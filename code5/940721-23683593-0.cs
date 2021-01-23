    internal static volatile bool isRunning;
    
    public static void Main()
        {
            Thread TT = new Thread(new ThreadStart(delegate()
                {
                    System.Timers.Timer oTimer = new System.Timers.Timer();
                    oTimer.Elapsed += new ElapsedEventHandler(Handler);
                    oTimer.Interval = 1000;
                    oTimer.Enabled = true;                 
                }));
            TT.Start();
        }
        private void Handler(object oSource,
            ElapsedEventArgs oElapsedEventArgs)
        {
            if(isRunning) return;
            
            isRunning = true;
            
            try
            {
               Console.WriteLine("foo");
               Thread.Sleep(500);         //simulate some work
               Console.WriteLine("bar");
            }
            finally { isRunning = false; }            
        }
