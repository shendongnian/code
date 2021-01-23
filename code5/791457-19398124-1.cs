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
                    var disposeAction = Disposable.Create(() =>
                        {
                            lock (gate)
                            {
                                resource.Dispose();
                                resource = null;
                            }
                        });
                    resourceDisposable = (resourceDisposable == null || resourceDisposable.IsDisposed)
                                             ? new RefCountDisposable(disposeAction)
                                             : resourceDisposable;
                    o.OnNext(resource);
                    return new CompositeDisposable(
                        resourceDisposable,
                        resourceDisposable.GetDisposable());
                }
            });
    }
