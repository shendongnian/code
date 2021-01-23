    public static IEnumerable<T> Generate<T>(Func<T> generator, int count)
    {
        for (int i = 0; i < count; i++)
            yield return generator();
    }
