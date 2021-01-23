        public IObservable<Either<Exception, TResult>> Poll2<TResult, TArg>(
            Func<TArg, IObservable<TResult>> asyncFunction,
            Func<TArg> parameterFactory,
            TimeSpan interval,
            IScheduler scheduler)
        {
            return Observable.Create<Either<Exception, TResult>>(
                observer =>
                    Observable.Defer(() => asyncFunction(parameterFactory()))
                              .Select(Either.Right<Exception, TResult>)
                              .Catch<Either<Exception, TResult>, Exception>(
                                ex => Observable.Return(Either.Left<Exception, TResult>(ex)))
                              .Concat(Observable.Defer(
                                () => Observable.Empty<Either<Exception, TResult>>()
                                                .Delay(interval, scheduler)))
                              .Repeat().Subscribe(observer));
        }
