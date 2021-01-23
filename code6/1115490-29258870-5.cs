    if (IsSubclassOfRawGeneric(typeof(SearchBoxGeneric<>), c.GetType()))
    {
        dynamic dynObj = c;
        object value = dynObj.Value;
        Console.WriteLine(value);
    }
