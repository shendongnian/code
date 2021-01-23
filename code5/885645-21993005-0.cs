    protected void orderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            ((Label)e.Item.FindControl("header")).Text = "The header" // Whatever you would like this to be;
        }
    }
