    static Task<TResult[]> SelectAsync<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, Task<TResult>> selector)
    {
        var results = new List<TResult>();
        foreach (var item in enumerable)
        {
            results.Add(await selector(item));
        }
        return results;
    }
