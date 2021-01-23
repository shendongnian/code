    var query = ( ... ).FirstOrDefault( );
    if( query != null )
    {
        if( query.PORT1 != null && !string.IsNullOrEmpty( query.PORT1.ToString( ) ) )
        {
        }
        else { ... }
    }
