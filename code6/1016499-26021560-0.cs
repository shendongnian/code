        DispatcherTimer _typingTimer;
        TimeSpan _typingTimerTimeout;
        bool _backgroundIsBlue;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void scanBox_TextChanged(object sender, EventArgs e)
        {
            if (_typingTimer == null)
            {
                _typingTimer = new DispatcherTimer();
                _typingTimerTimeout = TimeSpan.FromMilliseconds(300);
                _typingTimer.Interval = this._typingTimerTimeout;
                _typingTimer.Tick += new EventHandler(this.handleTypingTimerTimeout);
            }
            _typingTimer.Stop(); // Resets the timer
            _typingTimer.Tag = (sender as TextBox).Text; // This should be done with EventArgs
            _typingTimer.Start(); 
        }
        private void handleTypingTimerTimeout(object sender, EventArgs e)
        {
            var timer = sender as DispatcherTimer;
            if (timer == null)
            {
                return;
            }
            // Testing - updates window title
            var isbn = timer.Tag.ToString();
            windowFrame.Title = isbn;
            // Testing - flickers window background
            windowFrame.Background = _backgroundIsBlue ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Azure);
            _backgroundIsBlue = !_backgroundIsBlue;
            // The timer must be stopped! We want to act only once per keystroke.
            timer.Stop();
        }
