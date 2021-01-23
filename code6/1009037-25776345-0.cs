    using System;
    namespace System.Linq
    {
        public static class Enumerable
        {
            ...
            public static bool Any<TSource>(
                this IEnumerable<TSource> source,
                Func<TSource, bool> predicate)
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        return true;
                    }
                }
                return false;
            }
            ...
        }
    }
