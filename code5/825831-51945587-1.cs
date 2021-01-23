    public static class Extensions
        {
            public static IQueryable<T> IncludeMany<T>(this DbSet<T> model, params string[] includes)
                where T : class
            {
                var modelQuerable = model.AsQueryable();
                foreach (var value in includes)
                {
                    modelQuerable = modelQuerable.Include(value);
                }
                return modelQuerable;
            }
    }
