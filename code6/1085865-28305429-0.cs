        Timer mainTimer;
        Timer activityTimer;
        public Form1()
        {
            mainTimer = new Timer();
            activityTimer = new Timer();
            mainTimer.Interval = 60000;
            activityTimer.Interval = 2000;
            activityTimer.Tick += activityTick;
            InitializeComponent();
        }
 
        private void activityTick(object sender, EventArgs e)
        {
            mainTimer.Start();
            activityTimer.Stop();
        }
        private void onUserinput(object sender, EventArgs e)
        {
            mainTimer.Stop();
            activityTimer.Stop();
            activityTimer.Start();
        }
