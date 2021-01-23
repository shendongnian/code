        private Timer _aTimer;
        public void OnSomethingHappens()
        {  
            if (_aTimer != null)
            {    
                _aTimer.Enabled = true;  // start timer
                return;
            }
            _aTimer = new System.Timers.Timer();
            _aTimer.Elapsed += DoSomethingElse;
            _aTimer.Interval = 1000; // every 1 second
            _aTimer.Enabled = true;  // start timer
        }
        private void DoSomethingElse(object sender, ElapsedEventArgs e)
        {    
            _aTimer.Enabled = false; // stop timer
            // do w/e you want
        }
