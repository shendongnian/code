    public DataTable executeSelectQuery(String sql, Dictionary<String,String> parameters = null)
    {
        getConnection();
    
        try
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue("@"+param.Key, param.Value);
                }            
            }
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
