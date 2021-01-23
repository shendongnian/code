    public static IEnumerable<int> Range(int start, int count) {
        long max = ((long)start) + count - 1;
        if (count < 0 || max > Int32.MaxValue)
            throw Error.ArgumentOutOfRange("count");
        return RangeIterator(start, count); 
    }
    static IEnumerable<int> RangeIterator(int start, int count) {
        for (int i = 0; i < count; i++)
            yield return start + i;
    }
