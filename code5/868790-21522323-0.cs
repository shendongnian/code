    private void Repeater1_ItemDatabound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Retrieve button of the line
            var btn = e.Item.FindControl("btnSet") as Button;
            if (btn != null)
            {
                // Set text of button based on e.Item.DataItem;
            }
        }
    }
