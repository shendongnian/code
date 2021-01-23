    namespace System.Linq
    {
        using System.Collections.Generic;
        public static class LinqExtensions
        {
            public static IEnumerable<TResult> Cast<T, TResult>(this IEnumerable<T> self)
            {
                return self.Select(item => ConvertUtil.Convert<T, TResult>(item));
            }
        }
    }
