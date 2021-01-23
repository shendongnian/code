    public static IEnumerable<T> Join<T>(this IEnumerable<IEnumerable<T>> source, T separator)
    {
      bool firstTime = true;
      foreach (var collection in source)
      {
        if (!firstTime)
          yield return separator;
        foreach (var value in collection)
          yield return value;
        firstTime = false;
      }
    }
    ...
    var arrays = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 }};
    var result = arrays.Join(0).ToArray(); // result = { 1, 2, 3, 0, 4, 5, 6, 0, 7, 8, 9 }
