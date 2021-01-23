    GridView gv = new GridView();
    gv.DataSource = orders;
    gv.DataBind();
    Response.ClearContent();
    Response.Buffer = true;
    Response.AddHeader("content-disposition", "attachment; filename=MMDDYYYY.xls");
    Response.ContentType = "application/ms-excel";
    Response.Charset = string.Empty;
    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    gv.RenderControl(htw);
    Response.Output.Write(sw.ToString());
    
        // Save your content file to the disk
        System.IO.File.WriteAllText(@"C:\YourServerPath\MMDDYYYY.xls", sw.ToString());
    
    Response.Flush();
    Response.End();
