    public class OneTimeManualResetEvent
    {
        private ManualResetEvent _mre;
        private volatile bool _closed;
        private readonly object _locksmith = new object();
    
        public OneTimeManualResetEvent()
        {
            _mre = new ManualResetEvent(false);
            _closed = false;
        }
    
        public void WaitThenClose()
        {
            if (!_closed)
            {
                _mre.WaitOne();
                if (!_closed)
                {
                    lock (_locksmith)
                    {
                        Close();
                    }
                }
            }
        }
    
        public void Set()
        {
            if (!_closed)
                _mre.Set();
        }
    
        private void Close()
        {
            if (!_closed)
            {
                _mre.Close();
                _closed = true;
            }
        }
    }
