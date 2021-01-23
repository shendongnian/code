    public sealed class MyDispatcherTimer
    {
        DispatcherTimer dispatcherTimer;
        public void DispatcherTimerSetup(HttpClient httpClient)
        {
            Client = httpClient;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0); // TimeSpan for 1 Minute 0 secs
            
        }
    
        public void StartMyDispatcherTimer()
        {
            if (dispatcherTimer != null && !dispatcherTimer.IsEnabled)
                dispatcherTimer.Start();
        }
    }
    
