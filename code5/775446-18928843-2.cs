    [NotNull]
    private static Action<T> _eventsInternal = obj => { };
    
    private static event Action<T> Events
    {
        add { _eventsInternal += value; }
        remove { _eventsInternal -= value; }
    }
    
    protected virtual void OnEvents(T arg)
    {
        var handler = _eventsInternal;
        handler(arg);
    }
