    using System;
    using System.Timers;
    public class Clock
    {
        private readonly Timer _timer = new Timer(1000);
        private DateTime _yesturday = DateTime.Today;
        public event EventHandler NewDay;
        public Clock()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }
        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_yesturday != DateTime.Today)
            {
                if (NewDay != null) NewDay(this, EventArgs.Empty);
                _yesturday = DateTime.Today;
            }
        }
    }
