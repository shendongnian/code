    public delegate void TimerCallbackDelegate(object sender, ElapsedEventArgs e);
    public class TimerAbsolute : System.Timers.Timer
    {
        private DateTime m_dueTime;
        private TimerCallbackDelegate callback;
        public TimerAbsolute(TimerCallbackDelegate cb) : base()
        {
            if (cb == null)
            {
                throw new Exception("Call back is NULL");
            }
            callback = cb;
            this.Elapsed += this.ElapsedAction;
            this.AutoReset = true;
        }
        protected new void Dispose()
        {
            this.Elapsed -= this.ElapsedAction;
            base.Dispose();
        }
        public double TimeLeft
        {
            get
            {
                return (this.m_dueTime - DateTime.Now).TotalMilliseconds;
            }
        }
        public int TimeLeftSeconds
        {
            get
            {
                return (int)(this.m_dueTime - DateTime.Now).TotalSeconds;
            }
        }
        public void Start(double interval)
        {
            if (interval < 10)
            {
                throw new Exception($"Interval ({interval}) is too small");
            }
            DateTime dueTime = DateTime.Now.AddMilliseconds(interval);
            if (dueTime <= DateTime.Now)
            {
                throw new Exception($"Due time ({dueTime}) should be in future. Interval ({interval})");
            }
            this.m_dueTime = dueTime;
            // Timer tick is 1 second
            this.Interval = 1 * 1000;
            base.Start();
        }
        private void ElapsedAction(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now >= m_dueTime)
            {
                // This means Timer expired
                callback(sender, e);
                base.Stop();
            }
        }
    }
