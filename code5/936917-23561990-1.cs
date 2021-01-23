    // these actions should be invoked during cleanup
    private readonly List<Action> _cleanupActions = new List<Action>();
    public void Start()
    {
        foreach (var m in mappings)
        {
            // you need both closures in order to reference them inside
            // the cleanup action
            var mapping = m;
            PropertyChangedEventHandler handler = (s, e) => { /* ... */ };
            // attach now
            mapping.PropertyChanged += handler;
            // add a cleanup action to detach later
            _cleanupActions.Add(() => mapping.PropertyChanged -= handler);
    }
    public void Stop()
    {
        // invoke all cleanup actions
        foreach (var action in _cleanupActions)
            action();
    }
