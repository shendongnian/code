    // emit 0,1,2
    var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(3);
    
    source.Sample(TimeSpan.Zero, NewThreadScheduler.Default).Subscribe(x => {
            Console.WriteLine(x);
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
    });
