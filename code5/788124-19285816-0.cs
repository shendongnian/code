    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        foreach (var contextProperty in typeof(Context).GetProperties())
        {
            if (contextProperty.PropertyType.IsGenericType && 
                contextProperty.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            {
                var entityType = contextProperty.PropertyType.GenericTypeArguments[0];
                foreach(var decimalProperty in entityType.GetProperties().Where(p => p.PropertyType == typeof(decimal)))
                {    
                    var configurePropertyMethod = 
                        GetType()
                        .GetMethod("ConfigureProperty", BindingFlags.Static | BindingFlags.NonPublic)
                        .MakeGenericMethod(entityType);
                    configurePropertyMethod.Invoke(null, new object[] { modelBuilder, decimalProperty });
                }
            }
        }
    }
    private static void ConfigureProperty<T>(DbModelBuilder modelBuilder, PropertyInfo propertyInfo) 
        where T : class
    {
        var propertyExpression = BuildLambda<T, decimal>(propertyInfo);
        modelBuilder.Entity<T>().Property(propertyExpression).HasPrecision(10, 3);
    }
    private static Expression<Func<T, U>> BuildLambda<T, U>(PropertyInfo property)
    {
        var param = Expression.Parameter(typeof(T), "p");
        MemberExpression memberExpression = Expression.Property(param, property);
        var lambda = Expression.Lambda<Func<T, U>>(memberExpression, param);
        return lambda;
    }
