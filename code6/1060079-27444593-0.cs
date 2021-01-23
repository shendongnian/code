    public class BackgroundWorker : IDisposable
    {
        private static readonly BackgroundWorker SingleWorker = new BackgroundWorker();
        public static BackgroundWorker GetInstance()
        {
            return SingleWorker;
        }
        private readonly Thread _worker;
        private bool _disposed = false;
        private readonly AutoResetEvent _are = new AutoResetEvent(false); //can't remeber if it is true or false
        private BackgroundWorker()
        {
            _worker = new Thread(HandleWorker);
            _worker.Start();
        }
        private void HandleWorker()
        {
            while (true)
            {
                _are.Reset();
                //Check if there is work to be done
                //Do Work
                _are.Set();
                //Add a wait here Like wait for 2 minutes before you continue
            }
        }
        public void WaitForCompletion()
        {
            if (_disposed)
                throw new ObjectDisposedException(this.GetType().Name,"Object cannot be accessed when disposed");
            _are.WaitOne();
        }
        
        public void Dispose()
        {
            _disposed = true;
            _worker.Abort(0x0);
            _are.Set();
        }
    }
