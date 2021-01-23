    public static IEnumerable<T> Generate<T,U>(Func<U> initialize, 
        Func<U, Tuple<T>> generator)
    {
        var state = initialize();
        while (true)
        {
            var result = generator(state);
            if (null == result)
            {
                yield break;
            }
            yield return result.Item1;
        }
    }
