    IEnumerable<string> keys = lookupTable.Select( t => t.Key );
    foreach( string key in keys )
    {
        // use the value of key to access the List<CustomObject> from the ILookup
        Console.WriteLine( lookupTable[ key ] );
    }
