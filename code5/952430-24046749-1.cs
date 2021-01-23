    private Dictionary<Type, Func<TContract, Task>> _processorDictionary = new Dictionary<Type, Func<TContract, Task>>();
    public void AddEntry<TContract>(Func<TContract, Task> func)
    {
        _processorDictionary[typeof(TContract)] = func;
    }
