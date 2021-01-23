    public static List<T> GetAttributes<T>(this Enum value) where T : Attribute {
      
      List<T> attributes = new List<T>();
      IEnumerable<Enum> flags = Enum.GetValues(value.GetType()).Cast<Enum>().Where(value.HasFlag);
      if (flags != null) {
        foreach (Enum flag in flags) {
          MemberInfo info = flag.GetType().GetMember(flag.ToString()).FirstOrDefault();
          if (info != null)
            attributes.Add((T)info.GetCustomAttributes(typeof(T), false).FirstOrDefault());         
        }
        return attributes;
      }
      return null;
    } // GetAttributes   
    public static Expected GetAttributes<T, Expected>(this Enum value, Func<List<T>, Expected> expression) where T : Attribute {
      List<T> attributes = value.GetAttributes<T>();
      if (attributes == null)
        return default(Expected);
      return expression(attributes);
    } // GetAttributes 
