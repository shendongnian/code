    public class ExistingClass
    {
        public void Launch()
        {
            new TimerWrapper(this);
        }
        private sealed class TimerWrapper
        {
            private readonly ExistingClass _outer;
            private readonly Timer _t;
            public TimerWrapper(ExistingClass outer)
            {
                _outer = outer;
                //start timer
                _t = new Timer(state=>_outer.MyCallBack(this),
                               null, Timeout.Infinite, Timeout.Infinite);
            }
            public Timer Timer
            {
                get { return _t; }
            }
        }
        private void MyCallBack(TimerWrapper wrapper)
        {
            wrapper.Timer.
        }
    }
