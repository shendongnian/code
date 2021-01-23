    public static IEnumerable<List<T>> Split<T>(this List<T> source, int count)
    {
        int rangeSize = source.Count / count;
        int firstRangeSize = rangeSize + source.Count % count;
        int index = 0;
        yield return source.GetRange(index, firstRangeSize);
        index += firstRangeSize;
        while (index < source.Count)
        {         
            yield return source.GetRange(index, rangeSize);
            index += rangeSize;
        }
    }
