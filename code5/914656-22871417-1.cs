    public static class ObservableExtensions
    {
        public static IObservable<IList<T>> ToNonEmptyBuffers<T>(
            this IObservable<T> source,
            TimeSpan timespan,
            int count,
            IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            return source.Buffer(timespan, count, scheduler ?? Scheduler.Default)
                         .Where(buffer => buffer.Count > 0);
        }
    }
