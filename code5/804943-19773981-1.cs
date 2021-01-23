    protected void CategoryOnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView TargetGrid = e.Row.FindControl("TargetGrid") as GridView;
            HiddenField hdnCatlinkulink = e.Row.FindControl("hdnCatlinkulink") as HiddenField;
            SqlDataSource TargetLinks = e.Row.FindControl("TargetLinks") as SqlDataSource;
    
            if (TargetGrid != null && hdnCatlinkulink != null && TargetLinks != null)
            {
                string catlinkulink = hdnCatlinkulink.Value;
                TargetLinks.SelectParameters[0].DefaultValue = catlinkulink;
            }
        }
    }
