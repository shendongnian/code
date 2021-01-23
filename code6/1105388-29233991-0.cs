    public class ClearableReplaySubject<TSource, TClearTrigger> : IConnectableObservable<TSource>
    {
        private readonly IConnectableObservable<IObservable<TSource>> _underlying;
        private readonly SerialDisposable _replayConnectDisposable = new SerialDisposable();
        public ClearableReplaySubject(IObservable<TSource> src, IObservable<TClearTrigger> clearTrigger)
        {
            _underlying = clearTrigger.Select(_ => Unit.Default).StartWith(Unit.Default)
                .Select(_ =>
                {
                    var underlyingReplay = src.Replay();
                    _replayConnectDisposable.Disposable = underlyingReplay.Connect();
                    return underlyingReplay;
                })
                .Replay(1);
        }
        public IDisposable Subscribe(IObserver<TSource> observer)
        {
            return _underlying.Switch().Subscribe(observer);
        }
        public IDisposable Connect()
        {
            return new CompositeDisposable(_underlying.Connect(), _replayConnectDisposable.Disposable);
        }
    }
