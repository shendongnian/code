    var xs = Observable.Using(
        () => {                        
            var resource =  Disposable.Create(() => Console.WriteLine("Binned"));
            Console.WriteLine("Created");
            return resource;
        },
        res => Observable.Never<Unit>());
    
    Console.WriteLine("Subscribing");
    var sub1 = xs.Subscribe();
    var sub2 = xs.Subscribe();
    Console.WriteLine("Disposing");            
    sub1.Dispose();
