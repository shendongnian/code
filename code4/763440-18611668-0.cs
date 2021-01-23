    public class OncePerDayTimer : IDisposable
    {
        private DateTime _lastRunDate;
        private Timespan _time;
        private Timer _timer;
        private Action _callback;
        
        public OncePerDayTimer(Timespan time, Action callback)
        {
            _time = time;
            _timer = new Timer(CheckTime, null TimeSpan.FromSeconds(1), TimeSpan.FromSecondS(1));
        }
        
        private void CheckTime(object state)
        {
            if (_lastRunDate == DateTime.Today)
                return;
            
            if (DateTime.TimeOfDay < _time)
                return;
                
            _lastRunDate == DateTime.Today
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
