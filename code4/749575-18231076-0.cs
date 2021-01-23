        private DispatcherTimer _timer;
        public void StartTimer()
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Tick += _timer_Tick;
            }
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Start();
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Hi there");
            _timer.Stop();
        }
        void SelectionChangedEvent()
        {
            StartTimer();
        }
