    foreach(GridViewRow row in GridView2.Rows)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
        TextBox txtLimitLetter=(TextBox)e.Row.FindControl("txtLimitLetter");
        }
    
    }
