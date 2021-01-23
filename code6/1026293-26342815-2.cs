    // dump out the combined results to the console,
    // IRL you would subscribe to this to process the results
    var subscription = combined.Subscribe(Console.WriteLine);
    
    // add a stream of longs
    container.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));    
    Console.WriteLine("Stream 1 added");
    Console.ReadLine();
    
    // add another stream
    container.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));    
    Console.WriteLine("Step 2");
    Console.ReadLine();
    // this will unsubscribe from all the live streams
    subscription.Dispose();
