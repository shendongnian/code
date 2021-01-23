    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
       {
 
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
          DropDownList ddl = e.Row.FindControl("ddlCountries") as DropDownList;
         if(ddl != null)
         {
            ddl.SelectedIndexChanged += new EventHandler(ddlCountries_SelectedIndexChanged);
         }
       }
  
     }
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
         string selectedValue = ((DropDownList)sender).SelectedValue;
	     if(selectedValue== "Not Selected")
	     {
		    // Write code here for sending mail
	     }
      
     }
