        public static IQueryable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(
            this IQueryable<TOuter> outer,
            IQueryable<TInner> inner,
            Expression<Func<TOuter, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            return outer
                .AsExpandable()// Tell LinqKit to convert everything into an expression tree.
                .GroupJoin(
                    inner,
                    outerKeySelector,
                    innerKeySelector,
                    (outerItem, innerItems) => new { outerItem, innerItems })
                .SelectMany(
                    joinResult => joinResult.innerItems.DefaultIfEmpty(),
                    (joinResult, innerItem) => 
                        resultSelector.Invoke(joinResult.outerItem, innerItem));
        }
