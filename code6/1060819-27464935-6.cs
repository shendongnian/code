    Observable.Defer(() => 
        DateTime.Now.Hour < 9
      ? Observable.Timer(DateTime.Today.AddHours(9))
      : DateTime.Now.Hour < 13
      ? Observable.Timer(DateTime.Today.AddHours(13))
      : Observable.Timer(DateTime.Today.AddDays(1).AddHours(9)))
              .Repeat()
              .Subscribe(...);
