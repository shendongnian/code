    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var panel = (Panel) e.Item.FindControl("Panel1");
            if (true /*Condition for setting panel background color*/)
            {
                panel.BackgroundColor = Color.Red;
            }
        }
    }
