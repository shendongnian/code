    /// <summary>
    /// Determines whether a password is valid.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>A Tuple where Item1 is a boolean (true == valid password; false otherwise).
    /// And Item2 is the message validating the password.</returns>
    public Tuple<bool, string> IsValidPassword( string password )
    {
        if( password.Contains( " " ) )
        {
            return new Tuple<bool, string>( false, "Password cannot contain white spaces." );
        }
    
        if( !password.Any( char.IsNumber ) )
        {
            return new Tuple<bool, string>( false, "Password must contain at least one numeric char." );
        }
    
        // perhaps the requirements meant to be 1 or more capital letters?
        // if( !password.Any( char.IsUpper ) )
        if( password.Count( char.IsUpper ) != 1 )
        {
            return new Tuple<bool, string>( false, "Password must contain only 1 capital letter." );
        }
    
        if( password.Length < 8 )
        {
            return new Tuple<bool, string>( false, "Password is too short; must be at least 8 characters (15 max)." );
        }
    
        if( password.Length > 15 )
        {
            return new Tuple<bool, string>( false, "Password is too long; must be no more than 15 characters (8 min)." );
        }
    
        return new Tuple<bool, string>( true, "Password is valid." );
    }
