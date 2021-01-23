    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string property = null)
        { if (this.PropertyChanged != null)                this.PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        private TimeSpan timeLeft = TimeSpan.FromSeconds(60);
        public TimeSpan TimeLeft
        {
            get { return timeLeft; }
            set
            {
                timeLeft = value;
                RaiseProperty("ClockText");
                RaiseProperty("ValueLeft");
            }
        }
        public string ClockText { get { return timeLeft.ToString("m\\:ss"); } }
        public double ValueLeft { get { return TimeLeft.Ticks; } }
        private double maxValue = TimeSpan.FromSeconds(60).Ticks;
        public double MaxValue // number of seconds
        {
            get { return maxValue; }
            set
            {
                TimeLeft = TimeSpan.FromSeconds(value);
                maxValue = TimeLeft.Ticks;
                RaiseProperty("MaxValue");
            }
        }
        System.Threading.Timer newTimer;
        private bool timerStarted = false;
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = this;
            newTimer = new Timer(OnTimerTick);
            buttonStart.Click += buttonStart_Click;
        }
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (!timerStarted)
            {
                buttonStart.Content = "STOP";
                MaxValue = 60;
                timerStarted = true;
                newTimer.Change(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1)); // start timer right now and invoke every second
            }
            else
            {
                buttonStart.Content = "Start";
                timerStarted = false;
                newTimer.Change(0, Timeout.Infinite); // stop the timer
            }
        }
        void OnTimerTick(object state)
        { Dispatcher.BeginInvoke(() => TimeLeft -= TimeSpan.FromSeconds(1)); }
    }
