    var cancelSignal = new AsyncSubject<Unit>();
    var s = ScheduleWork(cts.Token.AsObservable());
    // .. to cancel ..
    Console.ReadKey();
    cancelSignal.OnNext(Unit.Default);
    cancelSignal.OnCompleted();
    
