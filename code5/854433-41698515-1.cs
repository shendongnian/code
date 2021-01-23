    public T GetData<T>(string name)
    {
        object data;
        mlApp.GetWorkspaceData(name, "base", out data);
        if (data == null)
            return default(T);
        if (data is T)
            return (T)data;
        else
            throw new InvalidCastException($"The variable '{name}', of type '{data.GetType().Name}' cannot be casted to type '{typeof(T).Name}'.");
    }
