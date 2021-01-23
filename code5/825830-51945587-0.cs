    public static IQueryable<T> IncludeMany<T>(this DbSet<T> model, params string[] includes)
                where T : class
            {
                var modelQuerable = model.AsQueryable();
                foreach (var value in includes)
                {
                    try
                    {
                        modelQuerable = modelQuerable.Include(value);
                    }
                    catch (Exception e)
                    {
                        //Do Something depending on exception
                    }
    
                }
                return modelQuerable;
            }
