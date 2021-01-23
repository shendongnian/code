        public static IObservable<T> MinimumInterval<T>(this IObservable<T> source, TimeSpan rate, IScheduler scheduler = null)
        {
            if (scheduler == null)
                scheduler = TaskPoolScheduler.Default;
            Func<IObserver<T>, IDisposable> subscribe = obs => {
                var nextTick = scheduler.Now;
                var subscriptions = new CompositeDisposable();
                Action<T> onNext = value => 
                {
                    var sendTime = Max(nextTick, scheduler.Now);
                    var disp = new SingleAssignmentDisposable();
                    disp.Disposable = scheduler.Schedule(sendTime, () => 
                    { 
                        subscriptions.Remove(disp); 
                        obs.OnNext(value);
                    });
                    subscriptions.Add(disp);
                    nextTick = sendTime + rate;
                };
                Action<Exception> onError = err => { subscriptions.Dispose(); obs.OnError(err); };
                Action onCompleted = () => { subscriptions.Dispose(); obs.OnCompleted(); };
                var listener = Observer.Create(onNext, onError, onCompleted);
                subscriptions.Add(source.Subscribe(listener));
                return subscriptions;
            };
            return Observable.Create<T>(subscribe);
        }
