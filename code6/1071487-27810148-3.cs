    public class Service : IService
    {
        private DbContext context;
        public Service(DbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryBuilder<T> Query<T>() where T : class
        {
            return new QueryBuilder<T>(this.context);
        }
    }
