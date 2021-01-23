    DataTable dt = new DataTable();
    using(SqlCommand cmd = new SqlCommand("schemaExec.SelTimeframeCode", _sqlConn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        using(var da = new SqlDataAdapter(cmd))
            da.Fill(dt);
    }
    cbTimeframe.DisplayMember = "TimeframeDesc";
    cbTimeframe.ValueMember = "TimeframeCode";
    cbTimeframe.DataSource = dt;     
        
