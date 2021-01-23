    protected void gridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        Image imgCtrl = (Image) e.Row.FindControl("imgCtrl");
        if(args.Row.RowType == DataControlRowType.DataRow)
        {
            If(e.Row.DataItem("BooleanField"))
            {
            imgCtrl.ImageUrl = TickImagePath;
            }
            else
            {
            imgCtrl.ImageUrl = CrossImagePath;  
            } 
        }
    }
