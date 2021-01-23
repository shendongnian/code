    protected void gvProduct_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            int unitQuantity = ... // get the value here
            Label lblUnitQuantity = (Label)e.Row.FindControl("lblUnitQuantity");
            lblUnitQuantity.Text = unitQuantity.ToString();
        }
    }
