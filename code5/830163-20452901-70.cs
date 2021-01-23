    var dispatcher = Dispatcher.CurrentDispatcher;
    Console.WriteLine("Calling from Thread: " + Thread.CurrentThread.ManagedThreadId);
    var source = Observable.Timer(TimeSpan.FromSeconds(1)).Spy("Timer");
    source.ObserveOnDispatcher().Spy("ObserveOn").Subscribe();
    Console.WriteLine("Subscribe returned");
    Console.WriteLine("Blocking the dispatcher");
    Thread.Sleep(2000);
    Console.WriteLine("Unblocked");
