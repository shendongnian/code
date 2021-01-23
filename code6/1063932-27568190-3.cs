    public static IEnumerable<T> RepeatElements<T>(this IEnumerable<T> source, int count)
    {
      foreach(T item in source)
        for(int i = 0; i < count; ++i)
          yield return item;
    }
