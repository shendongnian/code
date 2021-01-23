    public static IReadOnlyCollection<TDisposable> SelectDisposables<TItem, TDisposable>(
        this IEnumerable<TItem> enumerable, 
        Func<TItem,TDisposable> selector)
        where TItem : IDisposable
        where TDisposable : IDisposable
    {
        var temp = new List<TDisposable>();
        try
        {
            temp.AddRange(enumerable.Select(selector));
            return temp;
        }
        catch
        {
            foreach (var disposable in temp)
            {
                disposable.Dispose();
            }
            throw;
        }
    }
