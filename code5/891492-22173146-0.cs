    if(readAssess.HasRows)
    {
        while(readAssess.Read())
        {
            chkAssess = readAssess.GetString(0);
        }
    }
