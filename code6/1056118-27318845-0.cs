    private void LoadDataToTable()
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from Users";
        cmd.CommandType = System.Data.CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet dataset = new DataSet();
        adapter.Fill(dataset);
        this.grvItems.DataSource = dataset;
        this.grvItems.DataBind();
        Session["DataTable"] = dt;
    }
