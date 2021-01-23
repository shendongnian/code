    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies().ToList())
    {
        foreach (Type classType in assembly.GetTypes())
        {
             if (classType.IsClass
                        && !classType.IsAbstract
                        && classType.IsSubclassOf(typeof(LogMedia)))                     
             {
                  m_loggers.Add(Activator.CreateInstance(classType) as LogMedia);
             }
        }
    }
