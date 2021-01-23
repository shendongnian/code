    // adapted from: ClockTicker.cs (c) 2006 by Charles Petzold
    public class ClockTicker : DependencyObject
    {
        public ClockTicker()
        {
            StartTimer();
        }
        void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += (s, e) => { DateTime = DateTime.Now; };
            timer.Start();
        }
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ClockTicker));
    }
