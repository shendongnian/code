    void Main()
    {
        var data = new List<string>(){@"$[data for first line g", "oes here]\r\n$[data for ", "second line goes here]"};
        
        data.ToObservable()
            .SelectMany(s=>s)
            .WindowByExclusive(c => c=='$')
            .SelectMany(window=>window.ToList().Select(l=>string.Join(string.Empty, l)))
            .Where(s=>!string.IsNullOrEmpty(s))
            .Dump("WindowByExclusive");
    }
    
    // Define other methods and classes here
    public static class ObEx
    {
        public static IObservable<IObservable<T>> WindowByExclusive<T>(this IObservable<T> input, Func<T, bool> isWindowBoundary)
        {
            return Observable.Create<IObservable<T>>(o=>
            {
                var source = input.Publish().RefCount();
                var left = source.Where(isWindowBoundary).Select(_=>Unit.Default).StartWith(Unit.Default);
                return left.GroupJoin(
                                source.Where(c=>!isWindowBoundary(c)),
                                x=>source.Where(isWindowBoundary),
                                x=>Observable.Empty<Unit>(),
                                (_,window)=>window)
                            .Subscribe(o);
            });
        }
    }
