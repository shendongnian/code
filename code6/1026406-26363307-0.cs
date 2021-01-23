    public DbSet<TEntity> Set<TEntity>()
            where TEntity : class, IObjectState
    {
        var propertyInfos = GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (PropertyInfo property in propertyInfos )
        {
            if (property.PropertyType == typeof(FakeDbSet<TEntity>))
                return property.GetValue(this, null) as FakeDbSet<TEntity>;
        }
        // no joy, test for base class(es)
        var baseType = typeof( TEntity ).BaseType;
        while( typeof( object ) != baseType )
        {
            foreach( var property in propertyInfos )
            {
                if( property.PropertyType == 
                    typeof( FakeDbSet<> ).MakeGenericType( baseType )
                {
                    var baseTypeDbSet = property.GetValue(this, null);
                    var entityDbSet = // you will need to convert FakeDbSet<TBaseType> to FakeDbSet<TEntity>
                    
                    return entityDbSet;
                }
            }
            baseType = baseType.BaseType;
        }
        throw new Exception("Type collection not found");
    }
