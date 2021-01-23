    gvSample.DataSource = Data;
    ViewState["Data"] = Data;
    gvSample.DataBind();
----------
    protected void dl_Click(object sender, ImageClickEventArgs e)
    {
        var ds = (ProperDataType)ViewState["Data"]; // TODO: check for nulls
        string csv = ToCSV(ds); //gv.DataSource is null, DatasourceID aswell
        Response.ContentType = "application/csv";
        Response.AddHeader("content-disposition", "attachment; filename=file.csv");
        Response.Write(csv);
        Response.End();           
    }
