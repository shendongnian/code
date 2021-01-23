    public static ReactiveCommand<object> CreateAndSubscribe(Func<object> fn) 
    {
        var displayCommand = ReactiveCommand.Create();
        displayCommand.Subscribe(fn);
        return displayCommand;
    }
