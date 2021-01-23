    var xs = Observable.Using(
        () => {                        
            var resource =  Disposable.Create(() => Console.WriteLine("Binned"));
            Console.WriteLine("Created");
            return resource;
        },
        res => Observable.Return(1));
    
    Console.WriteLine("Subscribing");
    var sub1 = xs.Subscribe();
