    foreach(var mi in methods)
    {
        foreach(var p in mi.GetParameters())
        {
            Console.Write(p.ParameterType + ",");
        }
        Console.WriteLine();
    }
