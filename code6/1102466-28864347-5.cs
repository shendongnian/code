    public class Tests : ReactiveTest
    {
        public void Scenario()
        {
            var scheduler = new TestScheduler();
            var test = scheduler.CreateHotObservable<int>(    
                // set up events as per the OP scenario
                // using 1 dash = 100 ticks        
                OnNext(200, 1),
                OnNext(400, 2),
                OnNext(500, 3),
                OnNext(800, 4),
                OnNext(900, 5),
                OnNext(1500, 6),
                OnNext(1600, 7),
                OnNext(1700, 8),
                OnNext(1800, 9),
                OnNext(1900, 0),
                OnNext(2000, 1),
                OnNext(2100, 2),
                OnNext(2200, 3),
                OnNext(2300, 4)
                );
                
            test.SampleFirst(TimeSpan.FromTicks(499), scheduler)
                .Timestamp(scheduler)
                .Subscribe(x =>  Console.WriteLine(
                    "Time: {0} Value: {1}", x.Timestamp.Ticks, x.Value));
                    
            scheduler.Start();
            
        }
    }
