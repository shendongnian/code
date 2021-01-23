    public static object FieldWithAttribute<T>(this object obj)
    {
      var field = obj.GetType()
                     .GetProperties()
                     .SIngleOrDefault(x => x.CustomAattributes.Any(y => y.AttributeType == typeof(T));
    
      return field != null ? field.GetValue(obj) : null;
    }
