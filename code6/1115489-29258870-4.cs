    if (IsSubclassOfRawGeneric(typeof(SearchBoxGeneric<>), c.GetType()))
    {
        var prop = c.GetType().GetProperty("Value");
        object value = prop.GetValue(c);
        Console.WriteLine(value);
    }
