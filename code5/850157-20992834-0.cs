    public static Task<List<string>> GetItensFromDatabase()
    {
        return Task.Factory.StartNew<List<string>>(() => 
        { 
            List<string> names = new List<string>();
    
            using (ServerConn)
            {
                ServerConn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Names", ServerConn);
    
                var ds = new DataSet();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds); // this call lasts about 1 minute
    
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    names.Add(dr["Name"].ToString());
                }
            }
            return names;
        });
    }
