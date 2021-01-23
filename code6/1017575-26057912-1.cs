        using (OracleConnection con = new OracleConnection(YourConnectionString))
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                string query = "select * from table1 where id3 LIKE :var";
                cmd.CommandText = query;
                cmd.Parameters.Add("var", "%18:15%");
                cmd.Connection = con;
                
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                var tb = new DataTable();
                da.Fill(tb);
            }
        }  
