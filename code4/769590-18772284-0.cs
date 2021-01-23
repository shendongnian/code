    public void GetRowHeaders(GridView gridViewSample)
    {
        string commandstr = @"SELECT a.*, b.somecolumn FROM tablea as a inner join tableb as b on b.someid= a.someid WHERE ID!=0 ORDER BY ID";
        SqlCommand rowHeaderCmd = new SqlCommand(commandstr, sqlcon);
        sqlcon.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = rowHeaderCmd;
        da.Fill(dt);
        gridViewSample.DataSource = dt;
        gridviewSample.DataBind();
        sqlcon.Close();
    }
