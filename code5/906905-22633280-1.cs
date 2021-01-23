        TimeSpan retryInterval = new TimeSpan(0, 0, 5);
        DateTime startTime;
        DateTime retryTime;
        Timer checkInterval = new Timer();
       
        private void waitMethod()
        {
            checkInterval.Interval = 1000;
            checkInterval.Tick += checkInterval_Tick;         
            startTime = DateTime.Now;
            retryTime = startTime + retryInterval;
            checkInterval.Start();
        }
        void checkInterval_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= retryTime)
            {
                checkInterval.Stop();
                // Retry Interval Elapsed
            }   
        }
