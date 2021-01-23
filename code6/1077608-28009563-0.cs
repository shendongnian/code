    public partial class MainWindow : Window
    {
        private readonly DateTime _endDate;
        private readonly DispatcherTimer _timer;
        public MainWindow()
        {
            InitializeComponent();
            _endDate = new DateTime(2016, 1, 1, 15, 0, 0);
            _timer = new DispatcherTimer();
            _timer.Tick += CountDown;
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Start();
        }
        private void CountDown(object sender, EventArgs e)
        {
            var remainingTime = _endDate.Subtract(DateTime.Now);
            countDays.Text = string.Format("{0} Dagen", remainingTime.Days);
            countHours.Text = string.Format("{0} Uur", remainingTime.Hours);
            countMinutes.Text = string.Format("{0} Minuten", remainingTime.Minutes);
        }
    }
