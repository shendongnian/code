    void LoadPlugin(string fullPath)
    {
    Assembly assembly = Assembly.LoadFile(file);
    foreach (Module module in assembly.GetModules())
    {
    foreach (Type type in module.GetTypes())
    {
    if (type.IsSubclassOf(typeof(IPlugin)))
    { 
    //poll constructors and instantiate type
    //do work to load plugin based on values
    }
    }
    }
    }
