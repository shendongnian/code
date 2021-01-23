    Type interfaceType = typeof(IEventHandler<>);
    Assembly mscorlib = typeof(int).Assembly;
    Assembly systemcore = typeof(Enumerable).Assembly;
    var events = AppDomain.CurrentDomain.GetAssemblies()
        // We skip two common assemblies of Microsoft
        .Where(x => x != mscorlib && x != systemcore)
        .SelectMany(s => s.GetTypes())
        .Where(p => p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType)).ToArray();
