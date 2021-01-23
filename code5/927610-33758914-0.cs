        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter StringWriter = new System.IO.StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //batigol
        GridView1.AllowPaging = false;
        GridView1.DataSource = Session["uu"];
        GridView1.DataBind();
        //
        GridView1.RenderControl(HtmlTextWriter);
        Response.Write(StringWriter.ToString());
        Response.End();
