    try
    {
       DataTable dt = (DataTable)Session["userDataTable"];
       dt = ReadExcelFile(filename);
    
       if (dt.Rows.Count == 0)
       {
           Response.Write("<script language=\"javascript\">alert('The first sheet is empty.');</script>");
           return;
       }
    
       // Bind Datasource
       gridViewTest.DataSource = dt;
       gridViewTest.DataBind();
    
       // Enable Export button
       this.btnExport.Enabled = true;
    }
