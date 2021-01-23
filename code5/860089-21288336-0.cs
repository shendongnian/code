    public static class EntityExtensions
    {
        public static IQueryable<MyEntity> InBetween(this IQueryable<MyEntity> queryable,
            DateTime start, DateTime end)
        {
            return queryable.Where(x => x.DateColumn >= start && x.DateColumn < end);
        }
    }
