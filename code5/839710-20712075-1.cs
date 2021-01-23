    class Logging :IDisposable
    {
        ManualResetEvent _stop = new ManualResetEvent(false);
        Thread _worker = null;
        public Logging()
        {
            _worker = new Thread(AsyncThread);
            _worker.Start();
        }
        public void Dispose()
        {
            _stop.Set();
            _worker.Join();
        }
        public void AsyncThread()
        {
            ... 
        }
    }    
