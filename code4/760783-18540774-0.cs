    protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                Repeater parentRepeater = (Repeater)args.Item.FindControl("ParentRepeater");       
                childRepeater.DataSource = YourMethod(parentRepeater.ID);
                childRepeater.DataBind();
            }
        }
