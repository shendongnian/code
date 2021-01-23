    public partial class MainPage
      : PhoneApplicationPage
    {
        Stopwatch sw = new Stopwatch();
        DispatcherTimer newTimer = new DispatcherTimer();
    
        public MainPage()
        {
            InitializeComponent();
    
            newTimer.Interval = TimeSpan.FromMilliseconds(1000 / 30);
            newTimer.Tick += OnTimerTick;
        }
    
        void OnTimerTick(object sender, EventArgs args)
        {
            UpdateUI();
        }
    
        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            Stop();
        }
    
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            Pause();
        }
    
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            Start();
        }
    
        void UpdateUI()
        {
            textClock.Text = sw.ElapsedMilliseconds.ToString("0.00");
        }
    
        void Start()
        {
            sw.Reset();
            sw.Start();
            newTimer.Start();
            UpdateUI();
        }
    
        void Stop()
        {
            sw.Stop();
            newTimer.Stop();
            UpdateUI();
        }
    
        void Pause()
        {
            Stop();
        }
    
        void Resume()
        {
             sw.Start();
             newTimer.Start();
             UpdateUI();
        }
    }
