    public event Func<Journaling.Action, Task> DataChanged;
    protected Task OnDataChanged(Journaling.Action a)
    {
        var handlers = DataChanged;
        if (handlers == null)
            return Task.FromResult(0);
        var tasks = DataChanged.GetInvocationList()
            .Cast<Func<Journaling.Action, Task>>()
            .Select(handler => handler(a));
        return Task.WhenAll(tasks);
    }
