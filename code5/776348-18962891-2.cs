    class PeriodicUpdater
    {
        private System.Threading.Timer _timer;
        private TimeSpan _interval;
        private DateTime _lastUpdateTime = DateTime.MinValue;
        private Action _updateAction;
        private TimeSpan _freshness;
        public PeriodicUpdater(Action updateAction, TimeSpan interval, TimeSpan freshness)
        {
            _interval = interval;
            _updateAction = updateAction;
            _freshness = freshness;
            _timer = new Timer(TimerTick, null, _interval, TimeSpan.Infinite);
        }
        private void TimerTick(object state)
        {
            if ((DateTime.UtcNow - LastUpdateTime) >= _freshness)
            {
                _updateAction();
                _lastUpdateTime = DateTime.UtcNow;
            }
            _timer.Change(_interval, TimeSpan.Infinite);
        }
    }
