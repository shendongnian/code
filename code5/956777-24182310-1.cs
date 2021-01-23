    public static IEnumerable<TResult> Zip<T, TResult>(
            this IEnumerable<T> source,               
            Func<IList<T>, TResult> resultSelector,
            params IEnumerable<T>[] others)
    {
        if (resultSelector == null)
        {
            throw ArgumentNullException("resultSelector");
        }
        var enumerators = new List<IEnumerator<T>>(++others.Length);
        enumerators.Add(source.GetEnumerator());
        enumerators.AddRange(others.Select(e => e.GetEnumerator());
        var buffer = new T[enumerators.Count];
        while (true)
        {
            for (var i = 0; i < enumerators.Count; i++)
            {
                if (!enumerator[i].MoveNext)
                {
                    yield break;
                }
                buffer[i] = enumerator[i].Current;
            }
            yield return resultSelector(buffer);
        }
    }
    
