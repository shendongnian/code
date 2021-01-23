    if( ans > 0 )
    {
        if( string.IsNullOrWhiteSpace(line[0]) )
        {
             Result = "";
        }
        else
        {
             Result = line[0].Trim().ToUpper();
        }
    }
    else
    {
         Result = "";
    }
    
