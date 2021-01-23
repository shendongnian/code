    public static IObservable<string> ConsoleInputObservable(
        IScheduler scheduler = null)
    {
        scheduler = scheduler ?? Scheduler.Default;
        return Observable.Create<string>(o =>
        {
            return scheduler.ScheduleAsync(async (ctrl, ct) =>
            {
                while(!ct.IsCancellationRequested)
                {                    
                    var next = Console.ReadLine();
                    if(ct.IsCancellationRequested)
                        return;
                
                    o.OnNext(next);
                    await ctrl.Yield();
                }
            });
        });
    }
