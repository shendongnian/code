     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         LinkButton lnkbtn;
         if (e.Row.RowType == DataControlRowType.Header)
         {
              foreach (TableCell cell in e.Row.Cells)
              {
                   lnkbtn = (LinkButton)cell.Controls[0];
                   if (!string.IsNullOrEmpty(GridView1.SortExpression))
                   {
                       if (GridView1.SortExpression.Equals(lnkbtn.Text))
                       {
                            cell.BackColor = System.Drawing.Color.Crimson;
                       }
                   }
              }
         }
    }
