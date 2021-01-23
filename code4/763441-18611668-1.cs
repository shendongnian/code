    public class OncePerDayTimer : IDisposable
    {
        private DateTime _lastRunDate;
        private TimeSpan _time;
        private Timer _timer;
        private Action _callback;
        public OncePerDayTimer(TimeSpan time, Action callback)
        {
            _time = time;
            _timer = new Timer(CheckTime, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            _callback = callback;
        }
        private void CheckTime(object state)
        {
            if (_lastRunDate == DateTime.Today)
                return;
            if (DateTime.Now.TimeOfDay < _time)
                return;
            _lastRunDate = DateTime.Today;
            _callback();
        }
        public void Dispose()
        {
            if (_timer == null)
                return;
            _timer.Dispose();
            _timer = null;
        }
    }
