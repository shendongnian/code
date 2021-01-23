    public static void ForEach<T>(this IEnumerable<T> pEnumerable, Action<T> pAction) {
       foreach (var item in pEnumerable)
          pAction(item);
    }
    public static IEnumerable<T> ForEachWithContinue<T>(
       this IEnumerable<T> pEnumerable,
       Action<T> pAction
    ) {
       foreach (var item in pEnumerable)
          pAction(item);
       return pEnumerable;
    }
