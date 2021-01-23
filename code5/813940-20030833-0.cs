    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      //supposing id is the first cell,change the index according to your grid
      // hides the first column
      e.Row.Cells[0].Visible = false; 
      if(btn1Click)
      {
         //to set header text
         if (e.Row.RowType == DataControlRowType.Header)
         {
            e.Row.Cells[1].Text = "Cell Text";
            e.Row.Cells[2].Text = "Cell Text";
         }
      }
      else if(btn2Click)
      {
         //to set header text
         if (e.Row.RowType == DataControlRowType.Header)
         {
            e.Row.Cells[1].Text = "Cell Text";
            e.Row.Cells[2].Text = "Cell Text";
          }
      }
    }
    
