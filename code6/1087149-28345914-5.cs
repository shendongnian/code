    public static class Extensions {
        public static IEnumerable<Tuple<A, B>> zipWithInfinite<A, B>(this IEnumerable<A> a, IEnumerable<B> b) {
            if(!a.Any() || !b.Any())
                return new Tuple<A, B> [] { };
            var max_a_index = a.Count() - 1;
            return b.Select((x, i) => Tuple.Create(a.ElementAt(Math.Min(i, max_a_index)), x));
        }
    }
