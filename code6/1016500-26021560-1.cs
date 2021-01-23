        System.Windows.Forms.Timer _typingTimer; // WinForms
        // System.Windows.Threading.DispatcherTimer _typingTimer; // WPF
        public MainWindow()
        {
            InitializeComponent();
        }
        private void scanBox_TextChanged(object sender, EventArgs e)
        {
            if (_typingTimer == null)
            {
                /* WinForms: */
                _typingTimer = new Timer();
                _typingTimer.Interval = 300;
                /* WPF: 
                _typingTimer = new DispatcherTimer();
                _typingTimer.Interval = TimeSpan.FromMilliseconds(300);
                */
                _typingTimer.Tick += new EventHandler(this.handleTypingTimerTimeout);
            }
            _typingTimer.Stop(); // Resets the timer
            _typingTimer.Tag = (sender as TextBox).Text; // This should be done with EventArgs
            _typingTimer.Start(); 
        }
        private void handleTypingTimerTimeout(object sender, EventArgs e)
        {
            var timer = sender as Timer; // WinForms
            // var timer = sender as DispatcherTimer; // WPF
            if (timer == null)
            {
                return;
            }
            // Testing - updates window title
            var isbn = timer.Tag.ToString();
            windowFrame.Text = isbn; // WinForms
            // windowFrame.Title = isbn; // WPF
            // The timer must be stopped! We want to act only once per keystroke.
            timer.Stop();
        }
