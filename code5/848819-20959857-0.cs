    public static IEnumerable<T> GetRangeDecreasing<T>(IList<T> source, int startPosition, int count)
    {
        var index = startPosition;
        for (int  counter = 0; counter < count; counter++)
        {
            yield return source[index];
            index = (index - 1) % source.Count;
            if (index < 0)
                index += source.Count;
        }
    }
