    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string url = DataBinder.Eval(e.Row.DataItem, "Bit").ToString();
            if (url =="False")
            {
                e.Row.Cells[15].Enabled = false;
            }
        }
    }
