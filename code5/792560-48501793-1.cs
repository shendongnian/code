    public static class Monoid
    {
        public static T Concat<T>(this IMonoid<T> m, IEnumerable<T> values)
        {
            return values.Aggregate(m.Identity, (acc, x) => m.Combine(acc, x));
        }
    }
