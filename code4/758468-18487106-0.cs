    static IObservable<int> SomeRxWork()
    {
        return Observable.Create<int>(o =>
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            IDisposable sub = SomeAsyncWork(cts.Token).ToObservable().Subscribe(o);
            return new CompositeDisposable(sub, new CancellationDisposable(cts));
        });
    }
    static Task<int> SomeAsyncWork(CancellationToken token);
