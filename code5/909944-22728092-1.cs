        public void MyMethod()
        {
            Timer timer = new Timer();
            timer.Interval = new TimeSpan(0, 15, 0).TotalMilliseconds;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;
        }
    
        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Do your stuff here
        }
