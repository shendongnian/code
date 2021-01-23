    var observable = Observable.FromEvent(
        action => Console.WriteLine("Added"),
        action => Console.WriteLine("removed"));
    Console.WriteLine("Subscribing");
    var subscription = observable.Subscribe(unit => { });
    Console.WriteLine("disposing");
    subscription.Dispose();
    Console.WriteLine("done");
