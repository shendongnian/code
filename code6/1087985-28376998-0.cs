        string @namespace = "Supernova.Entities";
        var assembly = typeof(YourClass).GetTypeInfo().Assembly;
        var types = assembly.GetTypes()
            .Where(t => t.GetTypeInfo().IsClass && t.Namespace == @namespace)
            .ToList();
        types.ForEach(t => Console.WriteLine(t.Name));
