    public static IEnumerable<T> Extract<T>(String path)
    {
      var parseList = buildParser(typeof(T));
    
      foreach (string line in File.ReadLines(path))
      {
        var tokens = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var args = parseList.Zip(tokens, (parser, value) => parser(value));
    
        yield return (T)Activator.CreateInstance(typeof(T), args.ToArray());
      }
    }
    
    private static IEnumerable<Func<String, Object>> buildParser(Type t)
    {
      // For now, we're going to assume you only have one public constructor.
      var ci = t.GetConstructors().First();
    
      foreach (var pi in ci.GetParameters())
      {
        var parser = fetchParseMethod(pi.ParameterType);
        Func<String, Object> boxingParser;
        
        if (parser != null)
          boxingParser = value => parser.Invoke(null, new Object[] { value });
        else
          boxingParser = value => value;
    
        yield return boxingParser;
      }
    }
    
    private static System.Reflection.MethodInfo fetchParseMethod(Type t)
    {
      return (from mi in t.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
              let parms = mi.GetParameters()
              where mi.Name == "Parse" && parms.Length == 1 && parms.First().ParameterType == typeof(String)
              select mi).FirstOrDefault();
    }
