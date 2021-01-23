    public static class Extensions {
        public static IEnumerable<A> extend<A>(this IEnumerable<A> a, int count) {
            return a.Concat(Enumerable.Range(0, Math.Max(0, count - a.Count())).Select(_ => a.Last()));
        }
        public static IEnumerable<Tuple<A, B>> zipExtendingBoth<A, B>(this IEnumerable<A> a, IEnumerable<B> b) {
            if(!a.Any() || !b.Any())
                return new Tuple<A, B> [] { };
            return a.extend(b.Count()).Zip(b.extend(a.Count()), Tuple.Create);
        }
    }
