     List<Type> sysTypes = Assembly.GetExecutingAssembly()
         .GetType().Module.Assembly.GetExportedTypes().ToList();
     
     if (sysTypes.Contains(item.GetType())) {
         // do something usefull
     }
