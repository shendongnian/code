    public class MyWorker : IObservable<string>, IDisposable
    {
        private Task _task;
        private IObserver<string> _observer; 
        public IDisposable Subscribe(IObserver<string> observer)
        {
            _observer = observer;
            return this;
        }
        public void StartWork()
        {
            _task = new Task(() =>
            {
                while (true)
                {
                    // background work goes here
                    Thread.Sleep(2000);
                    if (_observer != null)
                    {
                        string status = DateTime.Now.ToString("G");
                        _observer.OnNext(status);
                    }
                }
            });
            _task.ContinueWith(r =>
            {
                if (_observer != null)
                {
                    _observer.OnCompleted();
                }
            });
            _task.Start();
        }
        public void Dispose()
        {
            if (_task != null)
            {
                _task.Dispose();
                _task = null;
            }
        }
    }
