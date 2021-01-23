    public static class QuerySortExtension
    {
        private static readonly Dictionary<string, Expression<Func<MyEntity, int>>> _orderingMap;
        private static readonly Expression<Func<MyEntity, int>> _defaultSort;
        public static IOrderedQueryable<MyEntity> LanguageSort(this IQueryable<MyEntity> query, string language)
        {
            Expression<Func<MyEntity, int>> sortExpression;
            if (!_orderingMap.TryGetValue(language, out sortExpression))
                sortExpression = _defaultSort;
            return query.OrderBy(sortExpression);
        }
        static QuerySortExtension()
        {
            _orderingMap = new Dictionary<string, Expression<Func<MyEntity, int>>>(StringComparer.OrdinalIgnoreCase) {
                { "EN", e => e.Status == Status.Pending ? 1 : e.Status == Status.Accepted ? 0 : 2 },
                { "JP", e => e.Status == Status.Pending ? 2 : e.Status == Status.Accepted ? 1 : 0 }
            };
            // Default ordering
            _defaultSort = e => (int)e.Status;
        }
    }
