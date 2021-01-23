    static bool IsControllerType(Type t)
    {
         return
            t != null &&
            t.IsPublic &&
            t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) &&
            !t.IsAbstract &&
            typeof(IController).IsAssignableFrom(t);
    }
