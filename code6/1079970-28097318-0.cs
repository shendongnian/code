    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv2 = (GridView)e.Row.FindControl("GridView2");
            //Call the stored procedure from SqlDataSource2, passing
            //the ID you need as your filter. Then, bind that result
            //set to your GridView.
            gv2.DataSource = YOUR_STORED_PROCEDURE(e.Row.Cells[0].Text);
            gv2.DataBind();
        }
    }
