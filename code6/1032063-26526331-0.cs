    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.timerStart();
        }
    
        DispatcherTimer updaterTimer;
        private bool InPopAlready;
        DateTime dt_signing_in;
    
        public void timerStart()
        {
            updaterTimer = new DispatcherTimer();
            updaterTimer.Tick += new EventHandler(updaterTimer_Tick);
            updaterTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            updaterTimer.Start();
        }
    
        private void updaterTimer_Tick(object sender, EventArgs e)
        {
            updaterTimer.Stop();
            checkSigningAvailable();
            updaterTimer.Start();
        }
    
        
    
        public void checkSigningAvailable()
        {
            if (dt_signing_in.CompareTo(DateTime.Now) < 0)
            {
                if (!InPopAlready)
                {
                    InPopAlready = true;
                    
                    // Calling your method and showing MessageBox
                    MessageBox.Show("Signing in is over!", "No more signing in!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
