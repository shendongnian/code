       foreach (Type type in customAssembly )
        {
           if (type.GetInterface("IPlugin") == typeof(IPlugin))
           {
             IPlugin plugin = Activator.CreateInstance(type) as IPlugin;                      
            }
        }
