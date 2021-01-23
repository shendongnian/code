    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
    {
        foreach (object obj in source)
        {
            if (!(obj is TResult))
                continue;
            yield return (TResult)obj;
        }
    }
