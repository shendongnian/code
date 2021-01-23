    public static IEnumerable<T> Mesh<T>(this IEnumerable<T> source, params IEnumerable<T>[] others)
    {
        var enumerators = new[] { source.GetEnumerator() }.Concat(others.Select(o => o.GetEnumerator())).ToList();
        var finishes = new bool[enumerators.Count];
        var allFinished = false;
        while (!allFinished)
        {
             allFinsihed = true;
             for (var i = 0; i < enumerators.Count; i++)
             {
                 IEnumerator<T> enumerator = enumerators[i];
                 if (!enumerator.MoveNext())
                 {
                     finishes[i] = true;
                     enumerator.Reset();
                     enumerator.MoveNext(); // Not sure, if we need it here, Reset says: BEFORE the first element
                 }
                 yield return enumerator.Current;
                 if (!finishes[i])
                 {
                    allFinished = false;
                 }
             }
         }
     }
