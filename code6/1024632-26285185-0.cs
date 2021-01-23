    public static class ObservableExtensions
    {
        public static IObservable<MyInfo> StuckInfos( this IObservable<MyInfo> source,
                IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            var sourcePub = source.Publish().RefCount();
            return sourcePub.Where(x => x.Status == "STARTED")
                .SelectMany(x => Observable.Return(x)
                    .Delay(TimeSpan.FromMinutes(30), scheduler)
                    .TakeUntil(sourcePub.Where(y => y.Id == x.Id
                                                    && y.Status != "STARTED")));
        }
    }
