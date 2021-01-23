            var entityTypeConfig = modelBuilder.GetType()
                .GetMethod( "Entity" )
                .MakeGenericMethod( type )
                .Invoke( modelBuilder, new object[] { } );
            entityTypeConfig.GetType()
                .GetMethods()
                .Single( mi => mi.Name == "ToTable" && mi.GetParameters().Count == 2 )
                .Invoke( entityTypeConfig, new object[] { attribute.Table, attribute.Schema } );
