    if( obType.IsGenericType && obType.GetGenericTypeDefinition() == typeof(Nullable<>) )
    {
        if( value == Runtime.PyNone )
        {
            result = null;
            return true;
        }
        // Set type to underlying type
        obType = obType.GetGenericArguments()[0];
    }
