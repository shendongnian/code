        static void Main(string[] args)
        {
            LimitedExecutionRateTaskScheduler scheduler = new LimitedExecutionRateTaskScheduler(5);
            TaskFactory factory = new TaskFactory(scheduler);
            List<string> symbolsToCheck = new List<string>() { "GOOG", "AAPL", "MSFT", "AGIO", "MNK", "SPY", "EBAY", "INTC" };
            while (true)
            {
                List<Task> tasks = new List<Task>();
                foreach (string symbol in symbolsToCheck)
                {
                    Task t = factory.StartNew(() => 
                    {
                        write(symbol);
                    }, CancellationToken.None, 
                       TaskCreationOptions.None, scheduler);
                    tasks.Add(t);
                } 
            } 
        }
        public static void write (string symbol)
        {
            DateTime dateValue = DateTime.Now;
            Console.WriteLine("Date and Time with Milliseconds: {0} doing {1}..",
                   dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"), symbol);
        }
