    public int ExecDB(string query, List<SqlParameter>parameters)
    {
         using(SqlConnection cn = new SqlConnection(connString))
         using(SqlCommand cmd = new SqlCommand(query, cn))
         {
             cn.Open();
             if(parameters.Count > 0)
                 cmd.Parameters.AddRange(parameters.ToArray());
             return cmd.ExecuteNonQuery();
         }
     }
