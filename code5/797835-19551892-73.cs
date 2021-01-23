        public IObservable<Either<Exception, TResult>> Poll<TResult, TArg>(
            Func<TArg, IObservable<TResult>> asyncFunction,
            Func<TArg> parameterFactory,
            TimeSpan interval,
            IScheduler scheduler)
        {
            return Observable.Create<Either<Exception, TResult>>(
                observer =>
                    {
                        var disposable = new CompositeDisposable();
                        var funcDisposable = new SerialDisposable();
                        bool cancelRequested = false;
                        disposable.Add(Disposable.Create(() => { cancelRequested = true; }));
                        disposable.Add(funcDisposable);
                        disposable.Add(scheduler.Schedule(interval, self =>
                            {
                                funcDisposable.Disposable = asyncFunction(parameterFactory())
                                    .Finally(() =>
                                        {
                                            if (!cancelRequested) self(interval);
                                        })
                                    .Subscribe(
                                        res => observer.OnNext(Either.Right<Exception, TResult>(res)),
                                        ex => observer.OnNext(Either.Left<Exception, TResult>(ex)));
                            }));
                        return disposable;
                    });
        }
