    public class Tests : ReactiveTest
    {
        public void Scenario1()
        {
            var scheduler = new TestScheduler();
            var live = scheduler.CreateHotObservable<Timestamped<int>>(
              OnNext(100, Timestamped.Create(1, new DateTimeOffset(100, TimeSpan.Zero))),
              OnNext(101, Timestamped.Create(1, new DateTimeOffset(200, TimeSpan.Zero))),
              OnNext(102, Timestamped.Create(2, new DateTimeOffset(300, TimeSpan.Zero))),
              OnNext(103, Timestamped.Create(2, new DateTimeOffset(400, TimeSpan.Zero))),
              OnNext(104, Timestamped.Create(3, new DateTimeOffset(450, TimeSpan.Zero))),
              OnNext(105, Timestamped.Create(3, new DateTimeOffset(455, TimeSpan.Zero))),
              OnCompleted<Timestamped<int>>(105)
            );            
                
            var windows = live.WindowByTimestamp(TimeSpan.FromTicks(200));
                                
            var numberedWindows = windows.SelectMany((x,i) =>
                x.Select(y => new {
                    WindowNumber = i,
                    Timestamp = y.Timestamp,
                    Value = y.Value }));
                            
            numberedWindows.Subscribe(x => Console.WriteLine(
                "Window: {0}, Time: {1} Value: {2}",
                x.WindowNumber,  x.Timestamp.Ticks, x.Value));
                    
            scheduler.Start();        
        }
    }
