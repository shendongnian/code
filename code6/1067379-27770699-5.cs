    public class CountDownTimer :  BindableBase
    {
        System.Diagnostics.Stopwatch sw;
        static readonly TimeSpan duration = TimeSpan.FromSeconds(60);
        private DispatcherTimer timer;
        public CountDownTimer() 
        {
            timer = new DispatcherTimer();
            sw = System.Diagnostics.Stopwatch.StartNew();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += timer_Tick;
        }
        private int? _seconds;
        public int? Seconds
        {
            get { return _seconds; }
            set { _seconds = value; NotifyPropertyChanged("Seconds"); }
        }
        private string _timeElapsed;
        public string TimeElapsed
        {
            get { return _timeElapsed; }
            set { _timeElapsed = value; NotifyPropertyChanged("TimeElapsed"); }
        }
         
        
        public void timer_Tick(object sender, object e)
        {
            if (sw.Elapsed < duration)
            {
                Seconds = (int)(duration - sw.Elapsed).TotalSeconds;
                TimeElapsed = String.Format("{0} second(s)", Seconds);
            }
            else
            {
                TimeElapsed = "Times Up";
                timer.Stop();
            }
        }
       public void StartCountDown()
        {
            sw.Start();
            timer.Start();
        }
        public void StopCountDown()
        {
            timer.Stop();
            sw.Stop();
        }
    }
