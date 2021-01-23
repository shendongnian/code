      protected void SYSGrid_RowDataBound(object sender, GridViewRowEventArgs e)    
            {
               if (e.Row.RowType == DataControlRowType.DataRow)
               {
    // Convert which control you use 
                  Label lblcol = (Label) e.Row.findcontrol("yourcolumnname") ;
            
                  if (lblcol.Text == "Missing")
                  {
                      e.Row.Cells[9].BackColor = Color.Red;
                      e.Row.Cells[9].ForeColor = Color.White;
                   }
                }
            }
