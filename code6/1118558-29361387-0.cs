    class GetIdleTime
    {
        private DispatcherTimer dispatcherTimer;
        private ClientIdleHandler _clientIdleHandler;
        
        //call for idle time
        public void callForIdletime()
        {
            _clientIdleHandler = new ClientIdleHandler();
            _clientIdleHandler.Start();
            //start timer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 10);
            dispatcherTimer.Start();
        }
        
        private void TimerTick(object sender, EventArgs e)
        {
            if (_clientIdleHandler.IsActive)//active
            {
                   //What you gonna do when idle
            }
         }
     }
