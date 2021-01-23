    static class DbContextExtensions
    {
        public static DbContext AsEagerLoadingContext(this IDbContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;
            //context.Configuration.AutoDetectChangesEnabled = false;
            
            return context;
        }
    }
