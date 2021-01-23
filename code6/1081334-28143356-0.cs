    // declare and define
    IDictionary<Type, dynamic> integers = new Dictionary<Type, dynamic>();
    integers.Add(typeof(sbyte), sbyte.MinValue);
    integers.Add(typeof(short), short.MinValue);
    // etc.
    // display
    int counter = 0;
    foreach (KeyValuePair<Type, dynamic> integer in integers)
    {
        Console.WriteLine(
            "i{0} has a type of {1} with a minimum value of {2}.",
            ++counter,
            integer.Key,
            integer.Value);
    }
