    public static List<T> Parse<T>(this Enum value, Func<Enum, T> expression) where T : Object {
  
       Type type = value.GetType();
    
      IEnumerable<Enum> values;
    
      if (type.GetCustomAttributes<FlagsAttribute>().Any())
        values = Enum.GetValues(type).Cast<Enum>().Where(value.HasFlag);
      else 
        values = new List<Enum> { value };
    
      if (values == null)
        return new List<Enum>(default(T));
    
      return expression.Select(values).ToList();
    
    } // Parse   
