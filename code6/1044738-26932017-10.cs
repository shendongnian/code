    Session["Data"] = GetData();
    gvSample.DataSource = Session["Data"];
    gvSample.DataBind();
    ...
    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        string csv = ToCSV(Session["Data"]);
        ...   
    }
