    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.Footer)
    {
    TextBox txtLimitLetter=(TextBox)e.Row.FindControl("txtLimitLetter");
    }
    }
