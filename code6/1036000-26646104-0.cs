    sqlConnectionCmdString.Open();
    using (reader = sqlCommand.ExecuteReader())
    {
        // iterate over the rows returned by the reader
        while (reader.Read()) 
        {
             // Data is accessible through the DataReader object here.
             IntializedPostNet[i] = reader[i].ToString(); //trying to add data from reader into an array errors here
        }
        reader.Close();
    }
    sqlConnectionCmdString.Close();
