    using(var conn = new SqlConnection(connString))
    {
        conn.Open();
        var command = new SqlCommand(sqlstring, conn);
        var adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        dbgCPNlist.DataSource = dt;
        dbgCPNlist.DataBind();
    }
