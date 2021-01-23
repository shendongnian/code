    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList Addfrequencydropdownlist = (DropDownList)e.Row.FindControl("Addfrequencydropdownlist");
            // ...            
        }
    }
