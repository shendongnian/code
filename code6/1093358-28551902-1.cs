    public static IReadOnlyCollection<TDisposable> SelectDisposables<TItem, TDisposable>(this IEnumerable<TItem> enumerable, Func<TItem,TDisposable> selector)
        where TItem : IDisposable
        where TDisposable : IDisposable
    {
        var temp = new List<TDisposable>();
        try
        {
            foreach (var item in enumerable)
            {
                temp.Add(selector(item));
            }
            return temp;
        }
        finally
        {
            foreach (var disposable in temp)
            {
                disposable.Dispose();
            }
        }
    }
