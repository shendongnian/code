    class ThreadManager : IThreadManager
    {
        private System.Threading.ManualResetEvent _Mre;
        private static CancellationTokenSource _CancellationToken;
        private int _ThreadCount;
        public ThreadManager(int threadCount)
        {
            _Mre = new System.Threading.ManualResetEvent(true);
            _CancellationToken = new CancellationTokenSource();
            _ThreadCount = threadCount;
        }
        public void DoWork(Action action)
        {
            _Mre.WaitOne();
            Task.Factory.StartNew(action, _CancellationToken.Token);
        }
        public void Stop()
        {
            _CancellationToken.Cancel();
        }
        public void Resume()
        {
            _Mre.Set();
        }
        public void Waite()
        {
            _Mre.Reset();
        }
    }
