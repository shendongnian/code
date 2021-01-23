    public static SqlDataReader ExecuteReader(string CommandName,
                                      SqlConnection Connection,
                                      params SqlParameter[] parameters)
    {
        using (SqlCommand cmd = new SqlCommand(CommandName, Connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            //Do something..                
            return cmd.ExecuteReader();
        }
    }
