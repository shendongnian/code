    namespace MyProject.MyLinqExtensions
    {
        public static class MyLinqExtensions
        {
            public static System.Collections.Generic.IEnumerable<TSource> DistinctBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> list, System.Func<TSource, TKey> expr)
            {
                return list.GroupBy(expr).Select(x => x.First());
            }
        }
    }
