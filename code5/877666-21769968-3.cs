    public static bool IsValidForeignKeyType( Type type )
    {
        var retVal = type.IsPrimitive ||
            type == typeof( string ) ||
            type == typeof( Guid );
        if( !retVal )
        {
            if( type.IsGenericType && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
            {
                var genArgType = type.GetGenericArguments().Single();
                retVal = genArgType.IsPrimitive || genArgType == typeof( Guid );
            }
        }
        return retVal;
    }
