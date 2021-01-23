    namespace Timer
    {
        public partial class MainPage : Page
        {
            DispatcherTimer mytimer = new DispatcherTimer();
            int currentcount = 0;
            public MainPage()
            {
                InitializeComponent();
                mytimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                mytimer.Tick += new EventHandler(mytime_Tick);
            }
            private void mytime_Tick(object sender, EventArgs e)
            {
                timedisplayBlock.Text = (++currentcount).ToString();
            }
            private void startButton_Click(object sender, RoutedEventArgs e)
            {
                mytimer.Start();
            }
        }
    }
