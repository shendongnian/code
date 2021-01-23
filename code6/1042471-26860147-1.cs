    void SetProperty<T>(string name, T value)
    {
        PropertySlot<T> property;
        if (!_properties.TryGetValue(name, out property))
        {
            property = new PropertySlot<T>();
            _properties[name] = property;
        }
        
        property.SetValue(value);
    }
    T GetProperty<T>(string name)
    {
        if (!_properties.TryGetValue(name, out property))
        {
            property = new PropertySlot<T>();
            _properties[name] = property;
        }
        return property.Value;
    }
