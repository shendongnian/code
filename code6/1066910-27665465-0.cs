    public static IEnumerable<T> OrderByExcept<T>(
                    this IEnumerable<T> source,
                     Predicate<T> exceptPredicate,
                     Func<IEnumerable<T>, IOrderedEnumerable<T>> projection)
    {
        var rest = new List<T>();
    
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                if (exceptPredicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
                else
                {
                    rest.Add(enumerator.Current);
                }
            }
        }
    
        foreach (var elem in projection(rest))
        {
            yield return elem;
        }
    }
