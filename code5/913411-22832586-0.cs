        DispatcherTimer idleTimer;
        DateTime timeNow;
        public ChildWindow1()
        {
            InitializeComponent();
    
            idleTimer = new DispatcherTimer();
            idleTimer.Start();
            idleTimer.Interval = TimeSpan.FromSeconds(1);
    
            idleTimer.Tick += new EventHandler(idleTimer_Tick);
            timeNow= DateTime.Now;
            // Initialise last activity time
        }
    
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void idleTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > timeNow.AddSeconds(30))
            {
                this.Close();
            }
        }
