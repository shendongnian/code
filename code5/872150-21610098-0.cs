    foreach( var pi in typeof( startingType ).GetProperties() )
    {
        var pt = pi.PropertyType;
        if( pt.IsClass && null != pt.GetProperty( "Name" ) )
        {
            ...
        }
    }
