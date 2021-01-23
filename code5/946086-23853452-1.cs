        private Timer _aTimer;
        public void OnSomethingHappens()
        {  
            if (_aTimer != null)
            {
                _aTimer.Enabled = true;
                return;
            }
            _aTimer = new System.Timers.Timer();
            _aTimer.Elapsed += DoSomethingElse;
            _aTimer.Interval = 1000;
            // start
            _aTimer.Enabled = true;
        }
        private void DoSomethingElse(object sender, ElapsedEventArgs e)
        {    // stop
            _aTimer.Enabled = false;
            // ... do w/e you want
        }
