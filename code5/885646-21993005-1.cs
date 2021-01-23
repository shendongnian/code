    protected void orderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            ((Literal)e.Item.FindControl("header")).Text = "The header" // Whatever you would like this to be;
        }
    }
