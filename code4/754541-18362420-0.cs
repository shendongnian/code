    public static T Convert<T>(this object obj)
    {
      T result;
      try
      {
        result = (T)System.Convert.ChangeType(obj, typeof(T));
        if (object.ReferenceEquals(result, null))
        {
          var typeConverter = !obj.IsNullable()
            ? TypeDescriptor.GetConverter(typeof(T))
            : new NullableConverter(typeof(T));
          result = obj is string
            ? (T)typeConverter.ConvertFromString(obj as string)
            : (T)typeConverter.ConvertTo(obj, typeof(T));
        }
      }
      catch (Exception)
      {
        result = default(T);
      }
      return result;
    }
    public static bool IsNullable<T>(this T obj)
    {
      return Nullable.GetUnderlyingType(typeof(T)) != null;
    }
