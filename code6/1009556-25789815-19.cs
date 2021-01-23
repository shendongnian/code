    static async Task<TResult[]> SelectAsync<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, Task<TResult>> selector)
    {
        var list = enumerable.ToList(); // materialize enumerable.
        var results = new TResult[list.Count];
        var index = 0;
        foreach (var item in list)
        {
            results[index] = await selector(item);
            index++;
        }
        return results;
    }
