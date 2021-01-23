    public string GetName(object obj)
    {
        if (!(obj is IEnumerable<object>))
            return GetName(obj as CustomClass);
    
        return obj.ToString();
    }
