    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           Label lbltotal= e.Row.FindControl("lbltotal") as Label; //explicit convert to label
           if(lbltotal != null)
             {
                String price=Session["price"].ToString();
                DataTable dt = GridView1.DataSource as DataTable;
               lbltotal.Text = dt.Compute("sum(price)", "").ToString();
             }
        }
