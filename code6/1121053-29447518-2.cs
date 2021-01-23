    static void Main()
    {
        Subject<string> sc = new Subject<string>();
        
        // kick off subscriptions here...
        // Perhaps with `ObserveOn` if background processing is required
        sc.Subscribe(x => Console.WriteLine("Subscriber1: " + x));
        sc.Subscribe(x => Console.WriteLine("Subscriber2: " + x));
        
        string input;
        while((input = Console.ReadLine()) != "q")
        {
            sc.OnNext(input);
        }
        sc.OnCompleted();
        
        Console.WriteLine("Finished");
    }
