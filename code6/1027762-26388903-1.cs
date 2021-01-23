    public class Tests : ReactiveTest
    {
        public void Test()
        {
            var scheduler = new TestScheduler();
            var xs = scheduler.CreateHotObservable<int>(
                OnNext(0, 0),
                OnNext(1, 1),
                OnNext(10, 10),
                OnNext(11, 11),
                OnNext(15, 15),
                OnCompleted(16, 0));                  
                
            xs.Publish(ps => 
            {       
                return ps.GroupByUntil(
                    p => p / 5,
                    grp => ps.Where(p => p / 5 != grp.Key))
                .SelectMany(x => x.ToList());
            })
            .Subscribe(Console.WriteLine);
            
            scheduler.Start();
        }
    }
