    public static IEnumerable<T> TopWithTies<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> selector, int n)
    {
        IEnumerable<T> orderedEnumerable = enumerable.OrderByDescending(selector);
        return
        (
            from p in orderedEnumerable
            let topNValues = orderedEnumerable.Take(n).Select(selector).Distinct()
            where topNValues.Contains(selector(p))
            select p
        );
    }
