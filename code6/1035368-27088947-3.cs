    // emits 0,1,2,3,4,5,6,7,8,9
    var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10); 
    
    source.Sample(TimeSpan.Zero, NewThreadScheduler.Default).Subscribe(x => {
            Console.WriteLine(x);
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();
    });
