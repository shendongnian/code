    public static partial class ObservableExtensions
    {
        public static IObservable<T> DistinctUntilChanged<T>(
            this IObservable<T> source, TimeSpan duration, IScheduler scheduler)
        {
            if (scheduler == null) scheduler = Scheduler.Default;
            return source.Timestamp(scheduler)
                         .DistinctUntilChanged(new Comparer<T>(duration))
                         .Select(ts => ts.Value);
        }
        private class Comparer<T> : IEqualityComparer<Timestamped<T>>
        {
            private readonly TimeSpan _duration;
            public Comparer(TimeSpan duration)
            {
                _duration = duration;
            }
            public bool Equals(Timestamped<T> x, Timestamped<T> y)
            {
                return (y.Timestamp - x.Timestamp < _duration) && x.Value.Equals(y.Value);
            }
            public int GetHashCode(Timestamped<T> obj)
            {
                return obj.Value.GetHashCode() ^ obj.Timestamp.GetHashCode();
            }
        }
    }
