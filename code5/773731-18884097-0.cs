         void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
         {
           DataRowView drv = (DataRowView)e.Row.DataItem; 
            if(e.Row.RowType == DataControlRowType.DataRow)
          {
             String State = drv["StateColumnName"].ToString();
          //Now You Have State So You Can Get All Code Values By State Name
             DataTable dtcodes = GetByState();
          //Now Bind This Code To DropDownList Of Codes
            DropDownList dropdownCodes = (DropDownList)e.Row.FindControl("dropdownCodes");
            dropdownCodes.DataSource = dtcodes;
            dropdownCodes.DataBind();
            }
         }
 
