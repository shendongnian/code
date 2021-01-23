    public static class ObservableExtensions
    {
        public static IObservable<IObservable<Timestamped<TSource>>> WindowByTimestamp
            <TSource>(
                this IObservable<Timestamped<TSource>> source,
                TimeSpan windowDuration)
        {
            long durationTicks = windowDuration.Ticks;
            
            return source.Publish(ps => 
                ps.GroupByUntil(x => x.Timestamp.Ticks / durationTicks,
                                g => ps.Where(x =>
                                     x.Timestamp.Ticks / durationTicks != g.Key)));
        }
    }
