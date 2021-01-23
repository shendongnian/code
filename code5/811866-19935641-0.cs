    public static IEnumerable<IEnumerable<T>> BatchesOf<T>(this IEnumerable<T> collection, int n)
    {
        return collection.Select((x, i) => new {Batch = i/n, Value = x})
            .GroupBy(x => x.Batch).Select(g => g.Select(x => x.Value));
    }
