    try
    {     
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
    
        string query = "select * from money where [Month]='January'";
        command.CommandText = query;
        OleDbDataReader reader = command.ExecuteReader();
    
        // start the total at 0
        int total = 0.0m;
    
        while (reader.Read())
        {
            // loop through all the fields in the reader
            for(int f = 0; f < reader.FieldCount; f++) {
                // read as a decimal and add to the total
                total += reader.GetDecimal(f);
            }
        }
    
        connection.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error" + ex);
    }
