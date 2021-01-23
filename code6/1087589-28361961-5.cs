    public static void IfNotNull(this T value, Action<T> action)
    {
       if(value != null)
          action(value);
    }
