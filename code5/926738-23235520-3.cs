    protected static StringWriter getStringWriterbyDataTable(DataTable dt, StringWriter stringWrite1 )
        {
        //System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
        DataGrid myDataGrid1 = new DataGrid();
        myDataGrid1.DataSource = dt;
        myDataGrid1.DataBind();
        myDataGrid1.RenderControl(htmlWrite1);
        return stringWrite1;
        }
