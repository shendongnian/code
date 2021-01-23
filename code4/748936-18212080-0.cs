    IDataReader cReader = cmd.ExecuteReader();
    
    if(cReader.Read())
    {
        string cText = cReader.GetString(1); // Second Column
    }
