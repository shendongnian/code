     protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               var dr = e.Row.DataItem as DataRowView; 
               
                  if(Convert.ToString(dr["valid"]) == 'Y')
                      e.Row.Enabled = false;
        
           }
      }
