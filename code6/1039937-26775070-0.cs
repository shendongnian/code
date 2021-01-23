    void Main()
    {
        var scenarios = new Scenarios();
        scenarios.Scenario1();
    }
    
    public class Scenarios : ReactiveTest
    {
        public void Scenario1()
        {
            var scheduler = new TestScheduler();
            var actions = scheduler.CreateHotObservable(
                OnNext(100, 1),
                OnNext(200, 2),
                OnNext(300, 3),
                OnNext(800, 4),
                OnNext(900, 5),
                OnNext(1400, 6),
                OnNext(1600, 7),
                OnNext(1700, 8),
                OnNext(1800, 9));
                
        var duration = TimeSpan.FromTicks(300);
            
        var buffered = actions.Publish(ps =>        
            ps.Buffer(() => ps.Throttle(duration, scheduler)));
            
            buffered.Timestamp(scheduler).Subscribe(
                x => Console.WriteLine("Timestamp: {0} Value: {1}",
                     x.Timestamp.Ticks, x.Value.Count()));
            
            scheduler.Start();
            
        }
    }
        
