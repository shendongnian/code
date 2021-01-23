    //...
    else if (depth > 0 && property.CanWrite)
    {
        if (typeof(IList).IsAssignableFrom(property.PropertyType))
        {
            var collection = (IList)Activator.CreateInstance(property.PropertyType);
            var value = property.GetValue(entity);
            foreach (var element in value as IEnumerable)
            {
                collection.Add(CloneInternal(element, depth - 1));
            }
            property.SetValue(cloned, collection);
        }
    }
