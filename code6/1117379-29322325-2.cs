    var namespaceStrings = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Select(type =>
            type.Namespace)
        .Where(@namespace =>
            @namespace != null);
