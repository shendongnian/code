    public static string ToStringNullSafe<T>(this T value)
    {
      if(value == null)
      {
        return null;
      }
      else
      {
         return value.ToString();
      }
    }
