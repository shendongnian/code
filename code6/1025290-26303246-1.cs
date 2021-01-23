    foreach (var event in paramSets)
    {
        foreach (var parameter in event)
        {
            // Do something with the parameter
            Console.WriteLine("Name: {0}, Value: {1}", parameter.Name, parameter.Value);
        }
    }
