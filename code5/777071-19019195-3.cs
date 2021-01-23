    public static IObservable<TSource> RetryWithDelay<TSource, TException>(this IObservable<TSource> source, Func<TException, int, TimeSpan> delayFactory, IScheduler scheduler = null)
    where TException : Exception
    {
        return Observable.Create<TSource>(observer =>
        {
    		scheduler = scheduler ?? Scheduler.CurrentThread;
    		var disposable = new SerialDisposable();
    		int retryCount = 0;
    
            var scheduleDisposable = scheduler.Schedule(TimeSpan.Zero,
            self =>
            {
                var subscription = source.Subscribe(
                observer.OnNext,
                ex =>
                {
                    var typedException = ex as TException;
                    if (typedException != null)
                    {
                        var retryDelay = delayFactory(typedException, ++retryCount);
                        self(retryDelay);
                    }
                    else
                    {
                        observer.OnError(ex);
                    }
                },
                observer.OnCompleted);
                disposable.Disposable = subscription;
            });
            return new CompositeDisposable(scheduleDisposable, disposable);
        });
    }
