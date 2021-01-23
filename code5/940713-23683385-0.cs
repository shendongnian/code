    public DataTable executeSelectQuery(String sql, String paramValue)
    {
        getConnection();
    
        try
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.AddWithValue(“@ParamName”, paramValue);
            // Create a DataAdapter to run the command and fill the DataTable
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
    
            return dt;    
        }
        catch (Exception e)
        {    
            throw e;
        }
        finally
        {    
            connection.Close();
        }    
    }
