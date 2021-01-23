        private Timer _dbCheckTimer;
        public void InitTimer()
        {
            _dbCheckTimer = new Timer();
            _dbCheckTimer.Elapsed += DBCheckTimer_Elapsed;
            _dbCheckTimer.Interval = 10000; // 10 seconds
            _dbCheckTimer.Start();
        }
        public void DisposeTimer()
        {
            _dbCheckTimer.Dispose();
        }
        void DBCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _dbCheckTimer.Stop();
            try
            {
                // check DB
            }
            finally
            {
                _dbCheckTimer.Start();
            }
        }
