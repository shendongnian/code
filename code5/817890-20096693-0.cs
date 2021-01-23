    public static IEnumerable<T> ExceptProblematic(this IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        if (!IsProblematic(item))
          yield return item;
      }
    }
