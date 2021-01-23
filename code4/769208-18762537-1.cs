    public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentException("source");
        var src = source.ToArray();
        for (int i = 1; i <= src.Length; i++)
            foreach (var result in permutations(src, i))
                return result;
    }
