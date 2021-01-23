    // generic poller
    public class RepositoryPoller<T>
    {
        public event EventHandler<RepositoryEventArgs<T>> OnQueryComplete;
        private readonly System.Timers.Timer _timer;
        private TimeSpan _timeSpan;
        // wire-up poll timer
        public RepositoryPoller()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += (sender, args) => Query();
        }
        // provide poll interval and repository, or set via properties
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
        // query for data
        private async void Query()
        {
            var results = (await Repository.GetAll()).ToArray();
            RaiseQueryCompleted(results);
            NotifyQueryCompleted(results);
        }
        // send results as event
        private void RaiseQueryCompleted(IEnumerable<T> results)
        {
            var handler = OnQueryComplete;
            if (handler != null)
                handler(this, new RepositoryEventArgs<T>(results));
        }
        // send results as message
        private void NotifyQueryCompleted(IEnumerable<T> results)
        {
            Messenger.Default.Send(new GenericMessage<IEnumerable<T>>(this, results));
        }
    }
    // event args holding queried items
    public class RepositoryEventArgs<T> : EventArgs
    {
        public RepositoryEventArgs(IEnumerable<T> result)
        {
            Results = result;
        }
        public IEnumerable<T> Results { get; set; }
    }
