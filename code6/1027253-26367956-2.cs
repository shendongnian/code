    internal static T[] DeserializeData<T>(string serializedData)
         where T : BaseObject, new()
    {
        var data = new List<T>();
    
        // Break into individual serialized items and decode each.
        foreach (var serializedItem in (serializedData ?? "").Split(','))
        {
            // Skip empty entries.
            if (serializedItem == "")
                continue;
            T item = new T();
    
            // Add additional checks for BaseObjectSpecific3, etc.
    
            item.BuildFromSerializedValue(serializedItem);
    
            data.Add(item);
        }
    
        return data.ToArray();
    }
