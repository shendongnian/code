    public static partial class Observable2
    {
      public static IObservable<long> Daily(params TimeSpan[] times)
      {
        Contract.Requires(times != null);
        Contract.Requires(Contract.ForAll(times, time => time > TimeSpan.Zero));
        Contract.Requires(Contract.ForAll(times, time => time.TotalDays < 1));
        return Daily(Scheduler.Default, times);
      }
      public static IObservable<long> Daily(IScheduler scheduler, params TimeSpan[] times)
      {
        Contract.Requires(times != null);
        Contract.Requires(Contract.ForAll(times, time => time > TimeSpan.Zero));
        Contract.Requires(Contract.ForAll(times, time => time.TotalDays < 1));
        if (times.Length == 0)
          return Observable.Never<long>();
        // Do not sort in place.
        var sortedTimes = times.ToList();
        sortedTimes.Sort();
        return Observable.Create<long>(observer =>
          Observable.Defer(() =>
          {
            var now = DateTime.Now;
            var next = sortedTimes.FirstOrDefault(time => now.TimeOfDay < time);
            var date = next > TimeSpan.Zero
                     ? now.Date.Add(next)
                     : now.Date.AddDays(1).Add(sortedTimes[0]);
            Debug.WriteLine("Next @" + date + " from " + sortedTimes.Aggregate("", (s, t) => s + t + ", "));
            return Observable.Timer(date, scheduler);
          })
          .Repeat()
          .Scan(-1L, (n, _) => n + 1)
          .Subscribe(observer));
      }
    }
