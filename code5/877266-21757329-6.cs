    public static IEnumerable<TSource> SafeTake<TSource>(
        this IEnumerable<TSource> source,
        int count
    ) where TSource : IDisposable
    {
        foreach(var item in source)
        {
            if(--count >= 0)
            {
                yield return item;
            }
            else
            {
                if(item != null)
                {
                    item.Dispose();
                }
            }
        }
    }
