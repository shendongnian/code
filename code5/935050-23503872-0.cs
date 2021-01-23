    SqlDataReader reader = command.ExecuteReader();
    try
    {
        while (reader.Read())
        {
        ...
        }
    }
    finally
    {
         // Always call Close when done reading.
         reader.Close();
    }
