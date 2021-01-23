    // get all control types
    Type typeControl = typeof(Control);
    List<Type> myTypes = new List<Type>();
    Assembly assembly = Assembly.GetAssembly(typeof(Control));
    foreach (Type type in assembly.GetTypes())
    {
        if (type.IsSubclassOf(typeControl) && !type.IsAbstract && type.IsPublic)
            myTypes.Add(type);
    }
