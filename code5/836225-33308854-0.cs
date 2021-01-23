    internal static bool IsControllerType(Type t)
    {
        return
            t != null &&
            t.IsClass &&
            t.IsVisible &&
            !t.IsAbstract &&
            typeof(IHttpController).IsAssignableFrom(t) &&
            HasValidControllerName(t);
    }
