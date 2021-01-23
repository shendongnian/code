    IPluginManager manager = this; // let this class implement IPluginManager
    Assembly assembly = Assembly.LoadFile(downloadedFilePath);
    foreach (Type type in assembly.GetTypes())
    {
        foreach (Type interfaceType in type.FindInterfaces
                                       ( delegate(Type m, object filterCriteria)
                                         {
                                             return m.FullName == typeof(IPlugin).FullName;
                                         }
                                       , null
                                       )
                )
        {
            IPlugin plugin = (IPlugin)Activator.CreateInstance(interfaceType);
            plugin.Activate(manager);
        }
    }
