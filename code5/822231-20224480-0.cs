    public bool TryParseInt32( this string str, out int result )
    {
        result = default(int);
    
        try
        {
            result = Int32.Parse( str );
        }
        catch
        {
            return false;
        }
    
        return true;
    }
