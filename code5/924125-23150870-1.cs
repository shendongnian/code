    foreach (var item in list)
    {
        foreach (var property in ReflectionHelper<T>.Properties)
        {
            object value = property(item);
            // feed to StringBuilder
        }
    }
