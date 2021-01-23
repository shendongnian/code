    public static class Utility
    {
        //public static IEnumerable<TTarget> Where<TSource, TTarget>(this IEnumerable<TSource> source, Expression<Func<TSource, bool>> predicate) where TTarget : class, TSource
        //{
        //     return source.Where(obj => obj is TTarget).Where(predicate.Compile()).Select(obj => obj as TTarget);
        //}
        public static IQueryable<TTarget> WhereIf<TSource, TTarget>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate) where TTarget : class, TSource
        {
            return source.Where(obj => obj is TTarget).Where(predicate).Select(obj => obj as TTarget);
        }
    }
