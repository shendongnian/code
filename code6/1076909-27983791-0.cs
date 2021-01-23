    public static IEnumerable<T> SkipTake<T>(this IEnumerable<T> input, int num, Action<List<T>> take)
    {
        var enumerator = input.GetEnumerator();
        var chunk = new List<T>();
        for (int i = 0; i < num; ++num)
        {
            if (!enumerator.MoveNext())
                break;
            chunk.Add(enumerator.Current);
        }
        take(chunk);
        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }
