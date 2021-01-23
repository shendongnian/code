    // these actions should be invoked during cleanup
    private readonly List<Action> _cleanupActions = new List<Action>();
    public void Start()
    {
        foreach (var m in mappings)
        {
            var mapping = m;
            // you need a close in order to reference it inside
            // the cleanup action
            PropertyChangedEventHandler handler = (s, e) => { /* ... */ };
            // attach now
            mapping.PropertyChanged += handler;
            // add a cleanup action to 
            _cleanupActions.Add(() => mapping.PropertyChanged -= handler;
    }
    public void Stop()
    {
        foreach (var action in _cleanupActions)
            action();
    }
