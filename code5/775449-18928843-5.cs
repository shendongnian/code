    [NotNull]
    private static Action<T> _eventsInternal = obj => { };
    
    private static event Action<T> Events
    {
        add { _eventsInternal += value; }
        remove { _eventsInternal -= value; }
    }
    
    protected static void OnEvents(T arg)
    {
        _eventsInternal(arg);
    }
