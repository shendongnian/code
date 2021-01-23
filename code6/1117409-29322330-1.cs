    Type interfaceType = typeof(IEventHandler<>);
    Assembly mscorlib = typeof(System.Int32).Assembly;
    Assembly system = typeof(System.Uri).Assembly;
    Assembly systemcore = typeof(System.Linq.Enumerable).Assembly;
    var events = AppDomain.CurrentDomain.GetAssemblies()
        // We skip three common assemblies of Microsoft
        .Where(x => x != mscorlib && x != system && x != systemcore).ToArray();
        .SelectMany(s => s.GetTypes())
        .Where(p => p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType)).ToArray();
