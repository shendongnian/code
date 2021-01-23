        DispatcherTimer dpTimer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            dpTimer.Tick += new EventHandler(dpTick);
            dpTimer.Interval = new TimeSpan(0, 0, 1);
            dpTimer.Start();
        }
        private void dpTick(object sender, EventArgs e)
        {
            DateTime present = DateTime.Now;
            timer_label.Content = present.Hour.ToString() + present.Minute.ToString() + present.Second.ToString();
        }
