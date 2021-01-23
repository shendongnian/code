    foreach( Type type in Assembly.GetExecutingAssembly().GetTypes() )
    {
        if( type.BaseType == typeof( pet ) )
        {
            pet aPet = Activator.CreateInstance( type ) as pet;
            // Now add aPet to your dictionary
        }
    }
