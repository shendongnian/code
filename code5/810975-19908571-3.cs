    public static class EnumerableExtensions
    {
        public static IEnumerable<int> FindIndices<T>(
            this IEnumerable<T> collection,
            Func<T, bool> predicate)
        {
            return collection.SelectMany((x, i) =>
                        Enumerable.Repeat(i, predicate(x) ? 1 : 0));
        }
    }
    var indices = myList.FindIndices(item =>
                       (item <= -Math.PI / 3) || (item >= Math.PI / 3));
