    class Program
        {
            private static void timer_TickEventHandler(object sender, EventArgs e)
            {
                // communicate to external service
            }
    		
    
            static void Main(string[] args)
            {
                var timeSpan = TimeSpan.FromSeconds(10);
    
                var timer = new DispatcherTimer();
                timer.Interval = timeSpan;
                timer.Tick += timer_TickEventHandler;
                timer.Start();
            }
        }
