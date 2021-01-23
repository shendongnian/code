    protected void ExporttoExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=Report.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        // ************************
        GridView1.AllowPaging = false; // <- disable paging then render
        // also do the binding
        GridView1.DataSource = myDataSource;
        GridView1.DataBind();
        // ************************
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
