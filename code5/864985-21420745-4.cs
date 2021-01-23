    public static bool TryParseEnum<T>( object value, out T result ) where T : struct
    {
        if( !typeof( T ).IsEnum )
            throw new ArgumentException( "T must be an Enum type." );
        if( value == null || value == DBNull.Value )
        {
            result = default( T );
            return false;
        }
        if( value is String )
        {
            return Enum.TryParse<T>( ( string )value, out result );
        }
        result = ( T )Enum.ToObject( typeof( T ), value );
        return Enum.IsDefined( typeof( T ), result );
    }
    public static Nullable<T> ParseEnum<T>( this object value ) where T: struct
    {
        T retVal;
        if( !TryParseEnum( value, out retVal ) )
        {
            return null;
        }
        return new Nullable<T>( retVal );
    }
