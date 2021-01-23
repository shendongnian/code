     public ActionResult ExcelDownload()
     {
          var datasource =  GetDataSource (); // Your Data Source
    
          if (datasource != null)
          {
             var gv = new GridView();
             gv.DataSource = datasource;
             gv.DataBind();
    
             HttpContext.Current.Response.ClearContent();
             HttpContext.Current.Response.Buffer = true;
             HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", "FileName.xls"));
             HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
             HttpContext.Current.Response.Charset = "UTF-8";
             HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
             HttpContext.Current.Response.Charset = "";
    
             using (StringWriter sw = new StringWriter())
             {
                 using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                 {
                     gv.RenderControl(htw);
                     HttpContext.Current.Response.Output.Write(sw.ToString());
                     HttpContext.Current.Response.Flush();
                     HttpContext.Current.Response.End();
                 }
             }
    
             return new EmptyResult();
          }
        return RedirectToAction("Index", "Home");
     }
