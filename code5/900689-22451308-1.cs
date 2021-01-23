     public void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
    
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
                     
         e.Row.Attributes.Add("onclick", "alert('helloworld " + e.Row.RowIndex + "')");
        }
    
       }
