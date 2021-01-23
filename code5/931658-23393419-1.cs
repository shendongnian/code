    protected void repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");
            lnkBtnEdit.CommandArgument = "foo args";
        }
     }
