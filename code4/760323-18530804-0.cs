    void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          //Your Condition
          If(a > B)
             lblproductname.Visible = true;
          //Others Lables
          ....
    
        }
    
      }
