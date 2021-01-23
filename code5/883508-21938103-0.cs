    public static class EvilHackyContextUtilities
    {
        private static MyDbContext GetDbContext(object entity)
        {
            var entityWrapper = entity.GetType().GetField("_entityWrapper").GetValue(entity);
            var objectContext = entityWrapper.GetType().GetProperty("Context").GetValue(entityWrapper, null) as ObjectContext;
            return new MyDbContext(objectContext, false);
        }
        public static void SetReadingsQueryableHack(Member entity)
        {
            if (entity.Readings is EvilHackyQueryableCollection<Reading>)
                return;
            IQueryable<Reading> query = GetDbContext(entity).Readings.Where(r => r.MemberID == entity.MemberID);
            entity.Readings = new EvilHackyQueryableCollection<Reading>(entity.Readings, query);
        }
    }
    internal class EvilHackyQueryableCollection<TEntity> : ICollection<TEntity>, IQueryable<TEntity>
        where TEntity : class
    {
        private readonly IQueryable<TEntity> _baseQuery;
        private readonly ICollection<TEntity> _baseCollection;
        public EvilHackyQueryableCollection(ICollection<TEntity> baseCollection, IQueryable<TEntity> baseQuery)
        {
            _baseQuery = baseQuery;
            _baseCollection = baseCollection;
        }
        #region ICollection members
        //All middle-man methods wrapping up the _baseCollection field.
        #endregion
        #region IQueryable members
        //All middle-man methods wrapping up the _baseQuery field.
        #endregion
    }
