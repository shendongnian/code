    var items = Observable.Range(0, 100000);
    var delay = Observable.Empty<int>().Delay(TimeSpan.FromMilliseconds(10));
    items.Buffer(20)
         .Select(batch => batch.ToObservable().Concat(delay))
         .Concat()
         .Subscribe(Console.WriteLine);
    
    Console.ReadLine();
