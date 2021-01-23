    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && 
            (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        { 
            // Here you will get the Control you need like:
            DropDownList dl = (DropDownList)e.Row.FindControl("dvAllServices ");
        }
    }
