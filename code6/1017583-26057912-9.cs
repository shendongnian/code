        using (OracleConnection con = new OracleConnection(YourConnectionString))
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                string query = string.Format("select * from table1 where id3 LIKE '{0}'", "%18:15%");
                cmd.CommandText = query;
                cmd.Connection = con;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                var tb = new DataTable();
                da.Fill(tb);
            }
        }  
