    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnEdit = (Button)e.Row.FindControl("btnEdit");
            //btnEdit.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference((Control)sender, "value$" + e.Row.RowIndex.ToString()));
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference((Control)sender, "value$" + e.Row.RowIndex.ToString()));
        }
    }
