    public static class CustomIQueryableExtensions
    {
        public static IQueryable<TResult> CommonJoinQueryable<TOuter, TInner, TResult>(this IQueryable<TOuter> outer,
                                                                              IQueryable<TInner> inner,
                                                                              Expression<Func<TOuter, TInner, TResult>>
                                                                                  resultSelector)
            where TOuter : IJoinedEntities
            where TInner : IRelatedEntity
        {
            // have to use expression trees to build the join otherwise cast to interface is in expression tree
            var outerParam = Expression.Parameter(typeof (TOuter), "outer");
            var outerBody = Expression.Lambda<Func<TOuter, int>>(Expression.Property(outerParam, "CId"), outerParam);
            var innerParam = Expression.Parameter(typeof (TInner), "inner");
            var innerBody = Expression.Lambda<Func<TInner, int>>(Expression.Property(innerParam, "Id"), innerParam);
            return outer.Join(inner, outerBody, innerBody, resultSelector);
        }
        public static IEnumerable<TResult> CommonJoinEnumerable<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer,
                                                                               IEnumerable<TInner> inner,
                                                                               Func<TOuter, TInner, TResult>
                                                                                   resultSelector)
            where TOuter : IJoinedEntities
            where TInner : IRelatedEntity
        {
            // have to use expression trees to build the join otherwise cast to interface is in expression tree
            Func<TOuter, int> outerJoin = outerParam => outerParam.Id;
            Func<TInner, int> relatedJoin = innerParam => innerParam.CId;
            return outer.Join(inner, outerJoin, relatedJoin, resultSelector);
        }
    }
