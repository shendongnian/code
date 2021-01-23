    public static class CustomIQueryableExtensions
    {
        public static IQueryable<TResult> CommonJoin<TOuter, TInner, TResult>(this IQueryable<TOuter> outer,
                                                                        IQueryable<TInner> inner,
                                                                        Expression<Func<TOuter, TInner, TResult>> resultSelector)
            where TOuter : IJoinedEntities
            where TInner : IRelatedEntity
        {
            return outer.Join(inner, o => o.Id, i => i.CId, resultSelector);
        }
    }
