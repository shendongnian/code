    var reader = cmd.ExecuteQuery();
    while (reader.Read()) 
    {
        if(int.Parse(reader.GetString(0))==0)
        {
             // success
        }
        else
        {
            // failure
        }
    };
