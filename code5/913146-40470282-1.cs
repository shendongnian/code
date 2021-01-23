    static ExpandoObject DeepCopy(ExpandoObject original)
    {
        var clone = new ExpandoObject();
    
        var _original = (IDictionary<string, object>)original;
        var _clone = (IDictionary<string, object>)clone;
    
        foreach (var kvp in _original)
            _clone.Add(kvp.Key, kvp.Value is ExpandoObject ? DeepCopy((ExpandoObject)kvp.Value) : kvp.Value);
    
        return clone;
    }
