    public static class ObservableExtensions
    {
        public static IObservable<MyInfo> StuckInfos(this IObservable<MyInfo> source,
            IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            return source.Publish(pub =>
                pub.Where(x => x.Status == "STARTED")
                    .SelectMany(
                        x => Observable.Return(x)
                            .Delay(TimeSpan.FromMinutes(30), scheduler)
                            .TakeUntil(pub.Where(y => y.Id == x.Id
                                                      && y.Status != "STARTED"))));
        }
    }
