    public static Type GetType(string typeName)
      {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
          {
            var allTypes = assembly.GetTypes();
            var type = allTypes.FirstOrDefault(t => t.Name == typeName);
            if (type != null)
              {
                 return type;
              }
          }
        throw new KeyNotFoundException("Can't find type");
      }
