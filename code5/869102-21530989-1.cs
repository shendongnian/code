    protected void ParentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            // code that binds ChildRepeater
            .....
            // check if ChildRepeater has no items
            if (((Repeater)e.Item.FindControl("ChildRepeater")).Items.Count == 0)
            {
                e.Item.Visible = false;
            }
        }
    }
