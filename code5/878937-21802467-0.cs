    public static object Select(string sql, OleDbTransaction dbt)
    {
      try
      {
         using (OleDbConnection con = new OleDbConnection(lib.dbc.ConnectionString))
         using (OleDbCommand cmd = new OleDbCommand(sql, con, dbt))
         {
             object obj = cmd.ExecuteScalar();
             return obj;
         }
      }
      catch (Exception ex)
      {
        /* deleted code - error message to the user */
        return null;
      }
    }
