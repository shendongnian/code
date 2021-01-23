    // declare and define
    IDictionary<Type, object> integers = new Dictionary<Type, object>();
    integers.Add(typeof(sbyte), sbyte.MinValue);
    integers.Add(typeof(short), short.MinValue);
    // etc.
    // display
    int counter = 0;
    foreach (KeyValuePair<Type, object> integer in integers)
    {
        Console.WriteLine(
            "i{0} has a type of {1} with a minimum value of {2}.",
            ++counter,
            integer.Key,
            integer.Value);
    }
