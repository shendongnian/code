    foreach (RepeaterItem ri in ParentRepeater.Items)
    {
        if (ri.ItemType == ListItemType.Item)
        {
            if (((Repeater)ri.FindControl("ChildRepeater")).Items.Count == 0)
            {
                ri.Visible = false;
            }
        }
    }
