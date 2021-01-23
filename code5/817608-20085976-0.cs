    public static IEnumerable<T> GetEveryNthItem(this IEnumerable<T> items, double step)
    {
        int cur = 0;
        double next = 0;
        foreach(var item in items)
        {
            if((int)Math.Round(next) == cur))
                yield return item;
        
            next += step
            cur++;
        }
    }
