    public partial class WmDevStopWatch : PhoneApplicationPage
        {
            Stopwatch stopWatch = new Stopwatch();
            DispatcherTimer oTimer = new DispatcherTimer();
            
            public WmDevStopWatch()
            {
                InitializeComponent();
    
                oTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                oTimer.Tick += new EventHandler(TimerTick);
    
            }
    
            void TimerTick(object sender, EventArgs e)
            {
                Dispatcher.BeginInvoke(() =>
                 {
                     string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                         stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds,
                         stopWatch.Elapsed.Milliseconds / 10);
    
                     textBlock1.Text = elapsedTime;
                 });
            }
    
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                stopWatch.Start();
                oTimer.Start();
            }
        }
