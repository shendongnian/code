    public static void Main (string[] args)
    {
      foreach(PropertyInfo prop in GetStringProperties(typeof(Credit_Card)))
        Console.WriteLine(prop.Name);              
      Console.ReadLine();
    }
    public static IEnumerable<PropertyInfo> GetStringProperties(Type type)
    {
      return GetStringProperties (type, new HashSet<Type> ());
    }
    public static IEnumerable<PropertyInfo> GetStringProperties(Type type, HashSet<Type> alreadySeen)
    {
      foreach(var prop in type.GetProperties())
      {
        var propType = prop.PropertyType;
        if (propType == typeof(string))
          yield return prop;
        else if(alreadySeen.Add(propType))
          foreach(var indirectProp in GetStringProperties(propType, alreadySeen))
            yield return indirectProp;
      }
    }
