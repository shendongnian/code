    Type t = data.GetType();
    if(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Tuple<,>))
    {
        var types = t.GetGenericArguments();
        Console.WriteLine("Datatype = Tuple<{0}, {1}>", types[0].Name, types[1].Name)
    }
