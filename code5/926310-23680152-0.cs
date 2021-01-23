    var grid = new System.Web.UI.WebControls.GridView();
    IQueryable<Customer> result = _db.Customers;
    var dataToExport = from b in result.AsEnumerable()
                                   select new
                                       {                                       
                                           b.CustomerContactName,
                                           b.CustomerContactNo,
                                           b.CustomerContactEmail
                                       };
    grid.DataSource = dataToExport.ToList();
    grid.DataBind();
    
    Response.ClearContent();
    Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
    Response.ContentType = "application/excel";
    var sw = new StringWriter();
    var htw = new HtmlTextWriter(sw);
    
    grid.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.End();
