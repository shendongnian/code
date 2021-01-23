    public static IObservable<T> CreateObservableRefCountedResource<T>(Func<T> resourceFactory)
        where T : class, IDisposable
    {
        T resource = null;
        RefCountDisposable resourceDisposable = null;
        var gate = new object();
        return Observable.Create<T>(o =>
            {
                lock (gate)
                {
                    resource = resource ?? resourceFactory();
                    resourceDisposable = resourceDisposable == null || resourceDisposable.IsDisposed
                                             ? new RefCountDisposable(resource)
                                             : resourceDisposable;
                    o.OnNext(resource);
                    return new CompositeDisposable(
                        resourceDisposable,
                        Disposable.Create(() =>
                            {
                                lock (gate)
                                {
                                    resource = null;
                                }
                            }));
                }
            });
    }
