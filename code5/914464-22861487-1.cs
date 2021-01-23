    Type targetType = defaultValue.GetType();
    foreach (var pair in dictionary)
    {
        if (pair.Key.IsAssignableFrom(targetType))
        {
            // Use pair.Value
        }
    }
