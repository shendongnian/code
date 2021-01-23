    public static IEnumerable<T> Union<T>(this IEnumerable<IEnumerable<T>> source)
    {
        var set = new HashSet<T>();
        foreach (var s in source)
        {
           foreach (var item in s)
           {
               if (set.Add(item))
                   yield return item;
           }
        }
    }
