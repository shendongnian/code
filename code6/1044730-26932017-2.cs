    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        //GridView gv = (GridView)this.Parent.Parent.Parent.Parent;
        //string csv = ToCSV(gv.DataSource); //gv.DataSource is null, DatasourceID aswell
        string csv = ToCSV(gvSample.DataSource);
        ...   
    }
