    if (!morzeovka.ContainsKey(key))
    {
        morzeovka.Add(key, value);
    }
    else
    {
        Console.WriteLine("morzeovka duplicate: {0}", key);
    }
    if (!latinka.ContainsKey(value))
    {
        latinka.Add(value, key);
    }
    else
    {
        Console.WriteLine("latinka duplicate: {0}", value);
    }
