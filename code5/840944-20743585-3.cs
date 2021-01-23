    string attachment = "attachment; filename=xxxx" + DateTime.Now + ".xls";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/ms-excel";
    StringWriter stw = new StringWriter();
    HtmlTextWriter htextw = new HtmlTextWriter(stw);
    ProductDetails.RenderControl(htextw);
    GridView dg = new GridView(); //Create an empty Gridview to bind to datatable.
    dg.AutoGenerateColumns = true;
    dg.DataSource = ProductDetails;
    dg.DataBind();
    dg.RenderControl(htw);
    Response.Write(stw.ToString());
    stw.Close();
    Response.End();    
