    public static bool ObjectHasStringData( this object obj )
    {
        if( obj == null )
            return false;
        var properties = obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var property in properties)
         ...
    }
