      public void Start_timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(00, 0, 10);
            bool enabled = timer.IsEnabled;
            timer.Start();
        }
        void timer_Tick(object sender, object e)
        {
          //function to execute
        
        }
