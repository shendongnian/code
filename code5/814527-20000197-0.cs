    if (String.IsNullOrEmpty(Language))
    {
    cmd.Parameters.AddWithValue("@lang", DBNull.Value);
    }
    
    else if(Language.Trim().Equals("N/A"))
    {
    cmd.Parameters.AddWithValue("@lang", DBNull.Value);
    }
    
    else if(Language.Trim().Equals(""))
    {
    cmd.Parameters.AddWithValue("@lang", DBNull.Value);
    }
    else
    {
    cmd.Parameters.AddWithValue("@lang", Language);
    }
