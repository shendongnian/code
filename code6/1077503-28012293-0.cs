    dbContext.GetType().GetProperties()
    .Where(p => p.PropertyType.IsGenericType)
    .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
    .Where(p => p.PropertyType.GetGenericArguments().First().IsSubclassOf(typeof(EntityBase)))
    .SelectMany(p => (IEnumerable<EntityBase>)p.GetValue(dbContext, null))
    .Select(obj => obj.ExampleProperty);
