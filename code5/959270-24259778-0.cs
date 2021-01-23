    public static IList<Ilist<T>> Segment<T>(
            this IEnumerable<T> source,
            int segments)
    {
        if (segments < 1)
        {
            throw new ArgumentOutOfRangeException("segments");
        }
        var list = source.ToList();
        var result = new IList<T>[segments];
        // In case the source is empty.
        if (!list.Any())
        {
            for (var i = 0; i < segments; i++)
            {
                result[i] = new T[0];
            }
            return result;
        }
        int remainder;
        var segmentSize = Math.DivRem(list.Count, segments, out remainder);
        var postion = 0;
        var segment = 0;
        while (segment < segments)
        {
            var count = segmentSize;
            if (remainder > 0)
            {
                remainder--;
                count++;
            }
            result[segment] = list.GetRange(position, count);
            segment++;
            position += count;
        }
        return result;
    }
