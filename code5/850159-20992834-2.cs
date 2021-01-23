    public static async Task<List<string>> GetItensFromDatabase()
    {
        List<string> names = new List<string>();
        using (ServerConn)
        {
            using (SqlCommand cmd = new SqlCommand("Select * From Names", ServerConn))
            {
                ServerConn.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        names.Add(dr["Name"].ToString());
                    }
                }
            }
        }
        return names;
    }
