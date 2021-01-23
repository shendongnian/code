    internal class MidnightTimer
    {
        internal event EventHandler Elapsed = delegate { };
        private Timer timer;
        private DateTime previousRun;
        internal MidnightTimer()
        {
            SystemEvents.TimeChanged += SystemEvents_TimeChanged;
            timer = new Timer();
            timer.AutoReset = false;
            timer.Elapsed += timer_Elapsed;
        }
        internal void Start()
        {
            previousRun = DateTime.Today;
            TimeSpan timeSpanToMidnight = GetNextMidnight().Subtract(DateTime.Now);
            timer.Interval = timeSpanToMidnight.TotalMilliseconds;
            timer.Start();
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (previousRun != DateTime.Today)
                Elapsed(this, EventArgs.Empty);
            timer.Stop();
            Start();
        }
        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            timer.Stop();
            Start();
        }
        private static DateTime GetNextMidnight()
        {
            return DateTime.Today.AddDays(1);
        }
    }
