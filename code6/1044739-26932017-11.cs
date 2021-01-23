    gvSample.DataSource = GetData();
    gvSample.DataBind();
    ...
    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        string csv = ToCSV(GetData());
        ...   
    }
