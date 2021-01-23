    public IObservable<object> CreateRegistryObservable(RegistryKey registryKey, string name, TimeSpan timeSpan)
        {
            return Observable.Create<object>(o =>
                {
                    var cancel = new CancellationDisposable();
                    
                    var currentStateSubscription = new SerialDisposable();
                    object currentValue = null;
                    
                    return new CompositeDisposable(cancel, NewThreadScheduler.Default.Schedule(
                        self => currentStateSubscription.Disposable =
                            CreateValueChangeObservable(registryKey, name, currentValue,
                                                        timeSpan, cancel.Token)
                                .Subscribe(value =>
                                {
                                    currentValue = value;
                                    self();
                                    o.OnNext(value);
                                },
                                o.OnError, 
                                currentStateSubscription.Dispose
                                )
                        ));
                });
        }
