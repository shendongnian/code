    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Cartesian<TFirst, TSecond, TResult>
                                          (this IEnumerable<TFirst> first, 
                                           IEnumerable<TSecond> second, 
                                           Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");
            return from item1 in first
                   from item2 in second
                   select resultSelector(item1, item2);
        }
    }
