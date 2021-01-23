    public static class DbContextExtensions
    {
        public static IEnumerable<T> SetOf<T>(this DbContext dbContext) where T : class
        {
            return dbContext.GetType().Assembly.GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface)
                .SelectMany(t => Enumerable.Cast<T>(dbContext.Set(t)));
        }
    }
