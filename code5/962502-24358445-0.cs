    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	// Add this line and try
    	GridView grd = (GridView)sender;
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }
