    public static String ExecuteSimpleSelectQuery(string ConnectionString, string _Query, string DataTableName)
    {
        List<string> list = new List<string>();
        using(SqlConnection conn = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(_Query, conn))
        {                
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add("name = " + reader.GetString(0));
                }
            }
        }
        return string.Join(Environment.NewLine, list);
    }
