    static IObservable<int> delay = Observable.Empty<int>().Delay(TimeSpan.FromMilliseconds(100));
    static async Task Run()
    {
        await Observable.Range(0, 1000)
            .Buffer(20)
            .Select(batch => batch.ToObservable().Concat(delay))
            .Concat()
            .Do(Console.WriteLine)
            .LastOrDefaultAsync();
    }
