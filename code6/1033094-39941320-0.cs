    public static IObservable<T> Suspendable<T>(
        this IObservable<T> source,
        IObservable<bool> pauser,
        bool initialState = false)
    {
        return 
            source.CombineLatest(pauser.StartWith(initialState), 
                                 (value, paused) => new {value, paused})
		          .Where(_=>!_.paused)
		          .Select(_=>_.value);
    }
