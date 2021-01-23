    try
    {	
    	using (var conn = new SqlConnection(connectionString))
    	using (var command = new SqlCommand("[dbo].[InsertRow]", conn) { 
    						CommandType = CommandType.StoredProcedure }) {
    		conn.Open();
    		command.Parameters.Add("@param1", SqlDbType.DateTime).Value = m.param1;
    		command.Parameters.Add("@param2", SqlDbType.NVarChar).Value = m.param2;
    		command.Parameters.Add("@param3", SqlDbType.Int).Value = m.param3;
    		command.Parameters.Add("@param4", SqlDbType.Bit).Value = m.param4;
    		command.Parameters.Add("@param5", SqlDbType.Int).Value = m.param5;
    		command.Parameters.Add("@param6", SqlDbType.Bit).Value = m.param6;
    		command.Parameters.Add("@param7", SqlDbType.Bit).Value = m.param7;
    		command.Parameters.Add("@param8", SqlDbType.VarChar).Value = m.param8;
    		command.Parameters.Add("@param9", SqlDbType.VarChar).Value = m.param9;
    		command.ExecuteNonQuery();
    	}
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
        return false;
    }
