    protected void btnAddNewEntry_Click(object sender, EventArgs e)
    {
        var data = GetUserControlData();
        var newData = new MyUserControlData() 
                          { Text1 = "New Item", 
                            Text2 = "Created at " + DateTime.Now.ToString() };
        data.Add(newData);
        rpt.DataSource = data;
        rpt.DataBind();
    }
