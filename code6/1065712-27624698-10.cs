    protected void Page_Load(object sender, EventArgs e)
            {
                Activate = true;
                var ds = new DataSet();
                var dt = new DataTable();
                dt.Columns.Add("Activate");
    
                dt.Rows.Add(new object[] { true });
                dt.Rows.Add(new object[] { false });
                dt.Rows.Add(new object[] { true });
    
                ds.Tables.Add(dt);
    
                rpHostUsersList.DataSource = ds;
                rpHostUsersList.DataBind();
            }
