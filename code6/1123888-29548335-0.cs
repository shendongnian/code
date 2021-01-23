    class TimerClass
    {
        public static int time;
    
        void timer_Tick(object sender, EventArgs e)
        {
            time++;
        }
        
        
        public void timeSetup()
        {
            timer = new DispatcherTimer();
        
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
        
            timer.Start(); 
        }
    }
