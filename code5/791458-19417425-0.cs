    internal sealed class ReconnectableObservable<TSource, TResult> : IConnectableObservable<TResult>
    {
        private ISubject<TSource, TResult> Subject
        {
            get { return _subject ?? (_subject = _factory()); }
        }
        private readonly object _gate = new object();
        private readonly IObservable<TSource> _source;
        private readonly Func<ISubject<TSource, TResult>> _factory;
        private ISubject<TSource, TResult> _subject;
        private IDisposable _subscription;
        public ReconnectableObservable(IObservable<TSource> source, Func<ISubject<TSource, TResult>> factory)
        {
            _source = source;
            _factory = factory;
        }
        public IDisposable Connect()
        {
            lock (_gate)
            {
                if (_subscription != null)
                    return _subscription;
                _subscription = new CompositeDisposable(
                    _source.Subscribe(Subject),
                    Disposable.Create(() =>
                    {
                        lock (_gate)
                        {
                            _subscription = null;
                            _subject = null;
                        }
                    }));
                return _subscription;
            }
        }
        public IDisposable Subscribe(IObserver<TResult> observer)
        {
            lock (_gate)
            {
                return Subject.Subscribe(observer);
            }
        }
    }
