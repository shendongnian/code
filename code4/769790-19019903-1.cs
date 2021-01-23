    protected void ExportToWord(object sender, EventArgs e)
    {
    
        //Get the data from database into datatable
        string strQuery = "select CustomerID, ContactName, City, PostalCode" +
                          " from customers";
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
     
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
            "attachment;filename=DataTable.doc");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
