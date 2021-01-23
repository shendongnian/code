    private void DataTableToExcel(DataTable dataTable)
    {
        StringWriter writer = new StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
        GridView gridView = new GridView();
        gridView.DataSource = dataTable;
        gridView.AutoGenerateColumns = true;
        gridView.DataBind();
        gridView.RenderControl(htmlWriter);
        htmlWriter.Close();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        Response.Charset = "";
        Response.Write(writer.ToString());
        Response.End();
    }
