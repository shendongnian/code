    public static class EntityFrameworkExtensions
    {
        public static void CompilePredicate<T>(this DbContext context, Expression<Func<T, bool>> predicate)
            where T : class
        {
            context.Set<T>().Where(predicate).ToString();
        }
    }
