    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {      
      if (e.Row.RowType == DataControlRowType.DataRow)
       {
         Label lbltotal=(Label) e.Row.FindControl("lbltotal");
         String price=Session["price"].ToString();
         DataTable dt = GridView1.DataSource as DataTable;
         lbltotal.Text = dt.Compute("sum(price)", "").ToString();
       }
     }
