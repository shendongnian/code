    public static IEnumerable<T> Generate<T>(Func<Func<Tuple<T>>> generator)
    {
        var tryGetNext = generator();
        while (true)
        {
            var result = tryGetNext();
            if (null == result)
            {
                yield break;
            }
            yield return result.Item1;
        }
    }
