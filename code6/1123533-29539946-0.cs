    public static class CombineOperators
    {
        public static IEnumerable<AB> Combine<A,B, AB>(this IEnumerable<A> first, IEnumerable<B> second, System.Func<A, B, AB> func)
        {
            using (var e1 = first.GetEnumerator())
            {
                using (var e2 = second.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        yield return func(e1.Current, e2.Current);
                    }
                }
            }
        }
    }
