    foreach (var c in objects)
    {
        foreach (dynamic i in c.data)
        {
            var property_value = i.GetType().GetProperty("PROPERTY_NAME").GetValue(i);
        }
    }
