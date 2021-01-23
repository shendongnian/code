    public static IEnumerable<T> GetValues<T>()
    {
      if (!typeof(T).IsEnum) 
        throw new ArgumentException("T must be an enumerated type");
      return Enum.GetValues(typeof(T)).Cast<T>();
    }
