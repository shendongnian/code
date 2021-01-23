    private ConcurrentQueue<Action> handlers = new ConcurrentQueue<Action>();
    public void Queue<TEvent>(TEvent e)
    {
        handlers.Enqueue(new Action(() =>
        {
            foreach (var handler in GetHandlers<TEvent>())
            {
                handler(e);
            }    
        }));
    }
    
    public void Emit()
    {
        Action act;
        while (handlers.TryDequeue(out act))
        {
            act();
        }
    }
    
    private IEnumerable<Action<TEvent>> GetHandlers<TEvent>()
    {
        return ObjectFactory.GetAllInstances(typeof(Action<TEvent>>));
    }
