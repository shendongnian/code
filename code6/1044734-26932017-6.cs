    ViewState["Data"] = GetData();
    gvSample.DataSource = ViewState["Data"];
    gvSample.DataBind();
    ...
    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        string csv = ToCSV(ViewState["Data"]);
        ...   
    }
