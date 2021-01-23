    public static class SqlHelper
    {
        public static int InsertUpdate(string connectionString, string sql, Dictionary<string, object> parameters)
        {
            int rows = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
        
                sqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                foreach (string key in parameters.Keys)
                {
                    cmd.Parameters.AddWithValue(key, parameters[key]);
                }
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }
    }
