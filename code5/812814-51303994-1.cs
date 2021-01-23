    public static int ParametersCommand(string query,List<SqlParameter> parameters)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
        try
        {
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {   // for cases where no parameters needed
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
    
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }
        catch (Exception ex)
        {
            AddEventToEventLogTable("ERROR in DAL.DataBase.ParametersCommand() method: " + ex.Message, 1);
            return 0;
            throw;
        }
    
        finally
        {
            CloseConnection(ref connection);
        }
    }
    private static void CloseConnection(ref SqlConnection conn)
    {
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
            conn.Dispose();
        }
    }
 
