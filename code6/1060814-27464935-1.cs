    Observable.Defer(() => 
        DateTimeOffset.Now.TimeOfDay.Hours <= 9
      ? Observable.Timer(DateTimeOffset.Now.Date.AddHours(9))
      : DateTimeOffset.Now.TimeOfDay.Hours <= 13
      ? Observable.Timer(DateTimeOffset.Now.Date.AddHours(13))
      : Observable.Timer(DateTimeOffset.Now.Date.AddDays(1).AddHours(13)))
              .Repeat()
              .Subscribe(...);
