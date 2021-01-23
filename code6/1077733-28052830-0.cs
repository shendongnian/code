    dbContext.GetType().GetProperties()
                                 .Where(p => p.PropertyType.IsGenericType)
                                 .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                 .Select(p => p.PropertyType.GetGenericArguments().First())
    							 .Where(t => t.IsSubclassOf(typeof(EntityBase)))
    							 .Select(t => ((IQueryable<EntityBase>)dbContext.Set(t)).Select(obj => obj.Id))
    							 .SelectMany(obj => obj)
    							 .Dump();
