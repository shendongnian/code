    // helper method to create channels
    private static IObservable<string> CreateChannelStream(
        string name, CompositeDisposable disposables)
    {
        // this hacks together a demo channel stream -
        // a stream of "frames" for the channel
        // for simplicity rather than using images, I use a string
        // message for each frame
        // how it works isn't important, just know you'll get a
        // message event every second
        var channel = Observable.Interval(TimeSpan.FromSeconds(1))
                                .Select(x => name + " Frame: " + x)
                                .Publish();
        disposables.Add(channel.Connect());
        return channel;
    }
    
    public static void Main()
    {       
        // for cleaning up the hot channel streams
        var disposable = new CompositeDisposable();
        
        // some channels
        var fuzz = CreateChannelStream("Fuzz", disposable);
        var channel1 = CreateChannelStream("Channel1", disposable);
        var channel2 = CreateChannelStream("Channel2", disposable);
                        
        // the button press event streams
        var eButton1 = new Subject<Unit>();
        var eButton2 = new Subject<Unit>();
        
        // the button presses are projected to
        // the respective channel streams
        // note, you could obtain the channel via a function call here
        // if you wanted to - to keep it close to the slides I'm not.
        var eChan1 = eButton1.Select(_ => channel1);
        var eChan2 = eButton2.Select(_ => channel2);
        
        // create the selection "stream of streams"
        // an IObservable<IObservable<string>> here
        // that starts with "fuzz"
        var sel = Observable.Merge(eChan1, eChan2).StartWith(fuzz);
        
        // flatten and select the most recent stream with Switch
        var screen = sel.Switch();
        
        // subscribe to the screen and print the frames
        // it will start with "fuzz"
        disposable.Add(screen.Subscribe(Console.WriteLine));
               
        bool quit = false;
        
        // a little test loop
        // entering 1 or 2 will switch
        // to that channel
        while(true)
        {
            var chan = Console.ReadLine();
            switch (chan.ToUpper())
            {
                case "1":
                    // raise a button 1 event
                    eButton1.OnNext(Unit.Default);
                    break;
                case "2":
                    // raise a button 2 event
                    eButton2.OnNext(Unit.Default);
                    break;  
                case "Q":
                    quit = true;
                    break;                
            }
            
            if(quit) break;
        }         
        
        disposable.Dispose();
    }
