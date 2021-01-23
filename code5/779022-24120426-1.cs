    var observable = Enumerable.Range(1, 10)
        .ToObservable(TimeSpan.FromSeconds(1));
    using (observable.Subscribe(Console.WriteLine))
    {
        Console.WriteLine("Press the Any key to abort");
        Console.ReadKey();
    }
