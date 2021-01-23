    try
    {
        using (var oleDbConnection = new SqlConnection(connectionString))
        {
            // Set the command object properties
            SqlCommand oleDbCommand = new SqlCommand()
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.CommandText = "[dbo].[InsertRow]";
            // Add the input parameters to the parameter collection
            // m.param1 is of DateTime type, m.param2 of string type, m.param3 of int type, etc.
            oleDbCommand.Parameters.AddWithValue("@param1", m.param1);
            oleDbCommand.Parameters.AddWithValue("@param2", m.param2);
            oleDbCommand.Parameters.AddWithValue("@param3", m.param3);
            oleDbCommand.Parameters.AddWithValue("@param4", m.param4);
            oleDbCommand.Parameters.AddWithValue("@param5", m.param5);
            oleDbCommand.Parameters.AddWithValue("@param6", m.param6);
            oleDbCommand.Parameters.AddWithValue("@param7", m.param7);
            oleDbCommand.Parameters.AddWithValue("@param8", m.param8);
            oleDbCommand.Parameters.AddWithValue("@param9", m.param9);
            // Open the connection, execute the query and close the connection.
            oleDbCommand.Connection.Open();
            oleDbCommand.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
        return false;
    }
