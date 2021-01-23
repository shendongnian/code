    var typesGroupedByNamespace = AppDomain.CurrentDomain
        .GetAssemblies()
        .SelectMany(t => t.GetTypes())
        .Where(t => t.IsClass && t.Namespace.StartsWith(@namespace))
        .GroupBy(t => t.Namespace.Substring(t.Namespace.LastIndexOf(".") + 1));
