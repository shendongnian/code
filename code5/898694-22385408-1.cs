    public bool IsViewModelOfType<T>()
    {
        Type type = typeof(T);
        if (!viewModelMapping.ContainsKey(type))
            return false;
        return viewModelMapping[type] == typeof(this);
    }
    
