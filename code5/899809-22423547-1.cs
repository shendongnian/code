    private object MyMethod(string className)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var type = assembly.GetTypes()
        .First(t => t.Name == className);
        return Activator.CreateInstance(type);
    }
