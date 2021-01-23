    protected void Repeater_OnItemCreated(Object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {    
              e.Item.FindControl(ctrl);
            }
            if (e.Item.ItemType == ListItemType.Header)
            {
              e.Item.FindControl(ctrl);
            }
        }
