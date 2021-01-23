    protected void fooRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            LinkButton lnkButton = (LinkButton)e.Item.FindControl("CheckBox");
            lnkButton.CssClass += string.Format(" {0}", IsExperienced());
        }
    }
