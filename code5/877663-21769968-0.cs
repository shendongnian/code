    var possibleEntityTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany( ass => ass.GetTypes() );
    modelBuilder.Properties()
        .Where( cp => 
            IsValidForeignKeyType( cp.PropertyType ) &&
            cp.Name.Length > 2 && 
            ( cp.Name.EndsWith( "ID" ) || cp.Name.EndsWith( "Id" ) ) &&
            !cp.Name.Substring( 0, cp.Name.Length - 2 ).Equals( cp.ReflectedType.Name, StringComparison.OrdinalIgnoreCase ) )
        .Configure( cppc => 
        {
            var sourcePropertyType = cppc.ClrPropertyInfo.PropertyType;
            var sourceEntityType = cppc.ClrPropertyInfo.ReflectedType;
            var targetEntityName = cppc.ClrPropertyInfo.Name.Substring( 0, cppc.ClrPropertyInfo.Name.Length - 2 );
            var icollectionType = typeof( ICollection<> ).MakeGenericType( sourceEntityType );
            // possible problem of multiple classes with same name but different namespaces
            // for this example I simply select the first but this should be more robust
            // e.g. check for ID/ClassNameID property in the class or require same 
            // namespace as the property's class
            var targetEntityType = possibleEntityTypes.FirstOrDefault( t =>
                t.Name == targetEntityName &&
                // check if the type has a nav collection property of the source type
                t.GetProperties().Any( pi =>
                    pi.PropertyType.IsGenericType &&
                    icollectionType.IsAssignableFrom( pi.PropertyType ) ) );
            if( null != targetEntityType )
            {
                // find the nav property
                var navPropInfos = targetEntityType.GetProperties()
                    .Where( pi =>
                        pi.PropertyType.IsGenericType && 
                        icollectionType.IsAssignableFrom( pi.PropertyType ) && 
                        pi.PropertyType.GetGenericArguments().First() == sourceEntityType );
                if( 1 != navPropInfos.Count() )
                {
                    // more than one possible nav property, no way to tell which to use; abort
                    return;
                }
                var navPropInfo = navPropInfos.First();
                // get EntityTypeConfiguration for target entity
                var etc = modelBuilder.GetType().GetMethod( "Entity" )
                    .MakeGenericMethod( targetEntityType )
                    .Invoke( modelBuilder, new object[] { } );
                var etcType = etc.GetType();
                var tetArg = Expression.Parameter( targetEntityType, "tet" );
                var mnpc = etcType.GetMethod( "HasMany" ).MakeGenericMethod( sourceEntityType )
                    .Invoke( etc, new[] { 
                        Expression.Lambda(
                            Expression.Convert( 
                                Expression.Property( 
                                    tetArg, 
                                    navPropInfo ),
                                icollectionType ),
                            tetArg ) } );
                string withMethodName = ( sourcePropertyType.IsPrimitive || sourcePropertyType == typeof( Guid ) )
                    ? "WithRequired"
                    : "WithOptional";
                var dnpc = mnpc.GetType().GetMethods().Single( mi =>
                    mi.Name == withMethodName && !mi.GetParameters().Any() )
                    .Invoke( mnpc, new object[] { } );
                var setArg = Expression.Parameter( sourceEntityType, "set" );
                var x = dnpc.GetType().GetMethod( "HasForeignKey" ).MakeGenericMethod( sourcePropertyType )
                    .Invoke( dnpc, new[]{
                        Expression.Lambda(
                            Expression.Property(
                                setArg,
                                cppc.ClrPropertyInfo ),
                            setArg ) } );
            }
        });
