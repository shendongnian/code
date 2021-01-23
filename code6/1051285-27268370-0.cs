        List<Assembly> allAssemblies = new List<Assembly>();
        string path = Path.GetDirectoryName("C:\\TemplatesDLL\\");
        List<ITemp> temp = new List<ITemp>();
        foreach (string dll in Directory.GetFiles(path, "*.dll"))
        {
              allAssemblies.Add(Assembly.LoadFile(dll));
        }
        foreach (Assembly assembly in allAssemblies)
        {
             var DLL = Assembly.LoadFile(assembly.Location.ToString());
             Type[] types = DLL.GetTypes();
             if (typeof(ITemp).IsAssignableFrom(types[0]))
             {
                  temp.Add(Activator.CreateInstance(types[0]) as ITemp); //adding all the instance into the list that is what I was looking for.
             }
        } 
