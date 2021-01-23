    class Program
        {
            private static void timer_TickEventHandler(object sender, EventArgs e)
            {
                // communicate to external service
            }
    		
    
            static void Main(string[] args)
            {
                var timeSpan = new TimeSpan(10000); // 10 seconds
    
                var timer = new DispatcherTimer();
                timer.Interval = timeSpan;
                timer.Tick += timer_TickEventHandler;
                timer.Start();
            }
        }
