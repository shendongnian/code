    public static IEnumerable<TSource> ExceptWithDuplicates<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }
            var secondList = second.ToList();
            return first.Where(s => !secondList.Remove(s));
        }
        public static IEnumerable<TSource> ExceptWithDuplicates<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException("first"); }
            if (second == null) { throw new ArgumentNullException("second"); }
            var comparerUsed = comparer ?? EqualityComparer<TSource>.Default;
            var secondList = second.ToList();
            foreach (var item in first)
            {
                if (secondList.Contains(item, comparerUsed))
                {
                    secondList.Remove(item);
                }
                else
                {
                    yield return item;
                }
            }
        }
