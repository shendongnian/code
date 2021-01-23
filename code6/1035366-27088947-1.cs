    var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);
    
    source.Sample(TimeSpan.Zero, NewThreadScheduler.Default).Subscribe(x => {
            Console.WriteLine(x);
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();
    });
