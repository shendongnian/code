    try
    {
        return assembly.DefineDynamicModule(name, name + ".dll");
    }
    catch(NotSupportedException)
    {
        return assembly.DefineDynamicModule(name);
    }
