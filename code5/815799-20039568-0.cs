    public static class ObservableEx
    {
        public static IObservable<T> ThrottleMax<T>(this IObservable<T> source, TimeSpan dueTime, TimeSpan maxTime)
        {
            return source.ThrottleMax(dueTime, maxTime, Scheduler.Default);
        }
        public static IObservable<T> ThrottleMax<T>(this IObservable<T> source, TimeSpan dueTime, TimeSpan maxTime, IScheduler scheduler)
        {
            return Observable.Create<T>(o =>
            {
                var hasValue = false;
                T value = default(T);
                var serialDisposable = new SerialDisposable();
                Action action = () =>
                {
                    if (hasValue)
                    {
                        serialDisposable.Disposable = Disposable.Empty;
                        o.OnNext(value);
                        hasValue = false;
                    }
                };
                return source.Subscribe(
                    x =>
                    {
                        if (!hasValue)
                        {
                            scheduler.Schedule(maxTime, action);
                        }
                        hasValue = true;
                        value = x;
                        serialDisposable.Disposable = scheduler.Schedule(dueTime, action);
                    },
                    o.OnError,
                    o.OnCompleted
                );
            });
        }
    }
