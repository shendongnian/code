    public class Repository : IRepository
    {
        private DBContext Contex { get; set; }
        public Repository(DBContext ctx)
        {
            this.Contex = ctx;
        }
        public QueryBuilder.IQueryBuilder<T> Query<T>()
        {
            return new QueryBuilder.QueryBuilder<T>(this.Contex);
        }
    }
