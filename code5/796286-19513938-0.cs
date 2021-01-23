    if (typeof(IEnumerable<EntityBase>).IsAssignableFrom(p.PropertyType))
    {
        var enumerable = (IEnumerable<EntityBase>)p.GetValue(obj);
        foreach (var entity in entities)
        {
            // do something
        }
    }
