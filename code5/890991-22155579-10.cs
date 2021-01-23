    public int ExecDB(string query, List<SqlParameter>parameters = null)
    {
         using(SqlConnection cn = new SqlConnection(connString))
         using(SqlCommand cmd = new SqlCommand(query, cn))
         {
             cn.Open();
             if(parameters != null && parameters.Count > 0)
                 cmd.Parameters.AddRange(parameters.ToArray());
             return cmd.ExecuteNonQuery();
         }
     }
