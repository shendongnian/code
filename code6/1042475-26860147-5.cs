    void SetProperty<T>(string name, T value)
    {
        IPropertySlot property;
        if (!_properties.TryGetValue(name, out property))
        {
            property = new PropertySlot<T>();
            _properties[name] = property;
        }
        
        ((PropertySlot<T>)property) .SetValue(value);
    }
    T GetProperty<T>(string name)
    {
        IPropertySlot property;
        if (!_properties.TryGetValue(name, out property))
        {
            property = new PropertySlot<T>();
            _properties[name] = property;
        }
        return ((PropertySlot<T>)property).Value;
    }
