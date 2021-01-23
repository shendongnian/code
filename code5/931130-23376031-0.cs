    protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var gvChild = sender as GridView;    
            var hfAppID = gvChild.Parent.FindControl("hfAppID") as HiddenField;
            var id = hfAppID.Value;
        }
    }
