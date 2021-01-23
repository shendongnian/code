    public static IEnumerable<TResult> LeftSegAggregate<TItem, TResult>(
        this IEnumerable<TItem> items, 
        Func<IEnumerable<TItem>, TResult> aggregator, 
        int segmentLength)
    {
        if (items == null)
            throw new ArgumentNullException("items");
        if (segmentLength <= 0)
            throw new ArgumentOutOfRangeException("segmentLength");
        int i = 0, c = 0;
        var segment = new TItem[segmentLength];
        foreach (var item in items)
        {
            c++;
            segment[i++ % segmentLength] = item;         
            yield return aggregator(segment.Take(c));
        }
    }
