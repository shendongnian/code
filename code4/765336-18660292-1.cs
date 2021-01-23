    Type[] pluginTypes = Assembly.LoadFile(s).GetTypes();
    
    foreach (Type t in pluginTypes)
    {
        if(t.GetInterfaces().Contains(typeof(ModuleInterface)))
        {
            var module = (ModuleInterface)Activator.CreateInstance(t);
            module.ReadAll(); // exception
        }
    }
