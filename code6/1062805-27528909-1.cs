    public class EntityFrameworkService<TContext> : IService
        where TContext : DbContext
    {
        protected readonly TContext context;
        public EntityFrameworkService(TContext context)
        {
            this.context = context;
        }
        public IEnumerable<Article> GetPublishedArticles()
        {
            ...
        }
    }
