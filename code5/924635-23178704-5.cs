    public static class CustomIQueryableExtensions
    {
        public static IQueryable<TResult> CommonJoin<TOuter, TInner, TResult>(this IQueryable<TOuter> outer,
                                                                        IQueryable<TInner> inner,
                                                                        Expression<Func<TOuter, TInner, TResult>> resultSelector)
            where TOuter : IJoinedEntities
            where TInner : IRelatedEntity
        {
            // have to use expression trees to build the join otherwise cast to interface is in expression tree
            var outerParam = Expression.Parameter(typeof (TOuter), "outer");
            var outerBody = Expression.Lambda<Func<TOuter, int>>(Expression.Property(outerParam, "Id"), outerParam);
            var innerParam = Expression.Parameter(typeof (TInner), "inner");
            var innerBody = Expression.Lambda<Func<TInner, int>>(Expression.Property(innerParam, "CId"), innerParam);
            
            return outer.Join(inner, outerParam , innerParam, resultSelector);
        }
    }
