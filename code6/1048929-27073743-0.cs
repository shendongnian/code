    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
               Label Label2 = (Label)e.Row.FindControl("Label2");
               //And then set your value
               Label2.Text = //Your value
          }
    }
