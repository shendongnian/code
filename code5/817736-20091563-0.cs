    public static DataTable ExecuteQuery(string query, string table)
        {
            using(SqlConnection cnn = new SqlConnection(ConnectionInfo))
            {
                SqlDataAdapter Adp = new SqlDataAdapter(query, cnn);
                DataSet Ds = new DataSet();
                Adp.Fill(Ds, table);
                return Ds.Tables[table];
            }
        }
