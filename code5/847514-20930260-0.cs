        Public void unlimQuery(string query,params object[] args)
           {
             SqlConnection conn = new        SqlConnection(_connectionString);
              conn.Open();
              string s =query;
              SqlCommand cmd = new SqlCommand(s);
              For(int i=0;i<  args.length;i++)
              cmd.Parameters.Add("@param"+i, args[i]);
              SqlDataReader reader = cmd.ExecuteReader();
              }
