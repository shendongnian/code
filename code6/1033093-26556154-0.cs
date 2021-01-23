    var shared = stream.Publish();
    var pausable = suspend
        .StartWith(initialState)
        .TakeUntil(shared.LastOrDefaultAsync())
        .DistinctUntilChanged()
        .Select(p => p ? shared : Observable.Empty<T>())
        .Switch();
    var disposable = new CompositeDisposable(pausable.Subscribe(o), shared.Connect());
    return disposable;
