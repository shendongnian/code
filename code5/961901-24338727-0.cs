    MySqlDataReader rdr = selectData.ExecuteReader();
    
    // Check whether the result set is empty.
    while (!rdr.HasRows)
    {
        rdr.Close();
    
        // Pause before trying again if appropriate.
    
        rdr = selectData.ExecuteReader();
    }
    
    while (rdr.Read())
    {
        // Read data here.
    }
