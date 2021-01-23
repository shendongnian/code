    public static bool IsValid( string str )
    {
        if( str.Length < 8 )
        {
            return false;
        }
    
        if( !str.StartsWith( "CA" ) && !str.StartsWith( "MA" ) )
        {
            return false;
        }
    
        int result;
        string end = str.Substring( str.Length - 6 );
        bool isValid = int.TryParse( end, out result );
    
        return isValid;
    }
