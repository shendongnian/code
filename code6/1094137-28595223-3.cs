    public class RepositoryPoller<T>
    {
        public event EventHandler<RepositoryEventArgs<T>>  OnQueryComplete;
        private readonly System.Timers.Timer _timer;
        private TimeSpan _timeSpan;
        public RepositoryPoller()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += (sender, args) => Query();
        }
        public RepositoryPoller(TimeSpan timeSpan, IRepository<T> repository)
            :this()
        {
            TimeSpan = timeSpan;
            Repository = repository;
        }
        public TimeSpan TimeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; _timer.Interval = _timeSpan.TotalMilliseconds; }
        }
        public IRepository<T> Repository { get; set; }
        public void Start()
        {
            if (TimeSpan.TotalMilliseconds > 0)
                _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
        private async void Query()
        {
            var results = (await Repository.GetAll()).ToArray();
            RaiseQueryCompleted(results);
            NotifyQueryCompleted(results);
        }
        private void RaiseQueryCompleted(IEnumerable<T> results)
        {
            var handler = OnQueryComplete;
            if (handler != null)
                handler(this, new RepositoryEventArgs<T>(results));
        }
        private void NotifyQueryCompleted(IEnumerable<T> results)
        {
            Messenger.Default.Send(new GenericMessage<IEnumerable<T>>(this, results));
        }
    }
    public class RepositoryEventArgs<T> : EventArgs
    {
        public RepositoryEventArgs(IEnumerable<T> result)
        {
            Results = result;
        }
        public IEnumerable<T> Results { get; set; }
    }
