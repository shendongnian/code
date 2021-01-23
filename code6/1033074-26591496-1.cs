    void Main()
    {
        var tests = new Tests();
        tests.Scenario();
    }
    
    // Note inheritance of ReactiveTest to get OnXXX helpers
    public class Tests : ReactiveTest
    {
        public enum FileAction
        {
            Modify,
            Rename
        }
    
        public void Scenario()
        {
            var scheduler = new TestScheduler();
            var actions = scheduler.CreateHotObservable<FileAction>(
                OnNext(200, FileAction.Modify),
                OnNext(300, FileAction.Modify),
                OnNext(500, FileAction.Modify),
                OnNext(700, FileAction.Modify),
                OnNext(900, FileAction.Modify),
                // Uncomment next line for
                // scenario with mod + rename in last window
                // OnNext(1200, FileAction.Modify),
                OnNext(1400, FileAction.Rename));
            
            actions.Publish(source => {
                return source.Window(
                    () => Observable.Timer(TimeSpan.FromTicks(500), scheduler)
                                    .Merge(source.Where(x => x == FileAction.Rename)
                                                .Select(_ => 0L)))
                    .TakeUntil(source.Where(x => x == FileAction.Rename))
                    .SelectMany(x => x.TakeLastBuffer(2))
                    .SelectMany(l => {
                        return l.LastOrDefault() == FileAction.Rename
                            ? l.TakeLast(2)
                            : l.TakeLast(1);
                    });
            })
            .Timestamp(scheduler) /* to show timings */
            .Subscribe(x => Console.WriteLine(
                "Event: {0} Timestamp: {1}",
                x.Value, x.Timestamp.Ticks));
            
            scheduler.Start();
            
        }
    }
