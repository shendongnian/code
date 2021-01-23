    protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Label tdInfoHeader = (Label)e.Item.FindControl("tdInfoHeader");
            tdInfoHeader.Visible = false;
        }
    }
