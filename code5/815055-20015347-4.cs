    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
    
        DataTable dt = new DataTable();
    
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Contact", typeof(int));
    
        dt.Rows.Add(1, "name1", 123);
        dt.Rows.Add(2, "name2", 456);
        dt.Rows.Add(3, "name3", 789);
    
        RadGrid1.DataSource = dt;
    }
