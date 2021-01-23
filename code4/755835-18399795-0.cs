    private void BindGrid()
    {
        //Your Code For Fill the Grid...Possibly If You Use Database than Fired Query to fetch data and fill Grid...
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var dr = e.Row.DataItem as DataRowView;
            if (dr["CustID"].ToString() == "60" || dr["CustID"].ToString() == "62")
            {
                e.Row.Enabled = false;  //OR dr.Enabled = false;
                //DISABLED Controls only     
                //((TextBox)e.Row.FindControl("TextBox1")).Enabled = false;
            }
        }
        BindGrid();
    }
