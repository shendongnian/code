    public static class DbContextExtensions
    {
        public static IEnumerable<T> SetOf<T>(this DbContext dbContext) where T : class
        {
            return typeof(T).Assembly.GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface)
                .SelectMany(t => dbContext.Set(t).OfType<T>());
        }
    }
