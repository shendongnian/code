    public static List<T> Slice<T>(this List<T> li, int start, int end)
    {
        if (start < 0)    // support negative indexing
        {
            start = li.Count + start;
        }
        if (end < 0)    // support negative indexing
        {
            end = li.Count + end;
        }
        if (start > li.Count)    // if the start value is too high
        {
            start = li.Count;
        }
        if (end > li.Count)    // if the end value is too high
        {
            end = li.Count;
        }
        var count = end - start;             // calculate count (number of elements)
        return li.GetRange(start, count);    // return a shallow copy of li of count elements
    }
