    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          if (e.Row.RowType == DataControlRowType.Footer)
          {
             Label lbl = (Label)e.Row.FindControl("lblTotal");
             lbl.Text = "Total";
          }
       }
