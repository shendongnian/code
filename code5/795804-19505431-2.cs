    void Main()
    {
        var throttleDuration = TimeSpan.FromSeconds(0.5);
        Func<long, IObservable<long>> throttleFactory =
            _ => Observable.Timer(throttleDuration);
	
        var sequence = Observable.Interval(TimeSpan.FromSeconds(1)).Throttle(throttleFactory);
		
        var subscription = sequence.Subscribe(Console.WriteLine);
		
        string input = null;
        Console.WriteLine("Enter throttle duration in seconds or q to quit");
        while(input != "q")
        {		
            input = Console.ReadLine().Trim().ToLowerInvariant();
            double duration;
	
            if(input == "q") break;
            if(!double.TryParse(input, out duration))
            {
                Console.WriteLine("Eh?");
                continue;
            }
            throttleDuration = TimeSpan.FromSeconds(duration);
        }
		
        subscription.Dispose();
        Console.WriteLine("Done");
    }
