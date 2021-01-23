    using (OracaleConnection con=new OracaleConnection())
    {
        conn.ConnectionString = connStr;
        conn.Open();
        using (OracleCommand cmd = new OracleCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = "sp_authenticate";  //name of your procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userid", OracleType.VarChar,50).value=userID;
            cmd.Parameters.Add("@password", OracleType.VarChar,50).value=pwd;
    
            DataTable dt = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
    
            if (dt.Rows.Count <= 0)
            {
                msg = "Invalid Login ID or Password"; }
            }
            return dt;
       }
