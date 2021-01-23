      GridView gv = new GridView();
      gv.DataSource = dataset; //Your datasource from database
      gv.DataBind();
      Response.ClearContent();
      Response.Buffer = true;
      Response.AddHeader("content-disposition", "attachment; filename=filename.xls");
      Response.ContentType = "application/vnd.ms-excel";
      Response.Charset = "";
      StringWriter sw = new StringWriter();
      HtmlTextWriter htw = new HtmlTextWriter(sw);
      gv.RenderControl(htw);
      Response.Write(sw.ToString());
      Response.Flush();
      Response.End();
