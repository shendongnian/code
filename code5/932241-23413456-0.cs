    class Example
    {
        public Example()
        {
            // create a stalled timer
            _pulse = new Timer(this.TakeAction);
        }
        TimeSpan _drawdelay = TimeSpan.FromSeconds(2);
        DateTime _lastAction = DateTime.MinValue;
        Timer _pulse;
        public void Start()
        {
            // start the timer by asking it to call the worker method ever 0.5 seconds
            _pulse.Change(0, 500); 
        }
        public void Stop()
        {
            // stop the timer by setting the next pulse to infinitely in the future
            _pulse.Change(Timeout.Infinite, Timeout.Infinite);
        }
        void TakeAction(object x)
        {
            lock (_pulse)
            {
                DateTime now = DateTime.Now;
                if(now - _lastAction > _drawdelay)
                {
                    // do work ...
                    _lastAction = now;
                }
            }
        }
    }
