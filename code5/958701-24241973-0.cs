    protected void Page_Load(object sender, EventArgs e)
    {
        DBAccess db = new DBAccess();
        db.FetchData(BindData);
    }
    
    private void BindData(SqlDataReader reader)
    {
        DataGridView1.DataSource = reader;
        DataGridView1.DataBind();
    }
