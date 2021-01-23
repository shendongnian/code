    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // Execute the following logic for Items and Alternating Items.
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (((DataRowView)e.Item.DataItem).Row["Type"].ToString() == "D")
            {
                ((Label)e.Item.FindControl("imagelabel")).Text = "<img src='/folder.png'>";
            }
            else
            {
                ((Label)e.Item.FindControl("imagelabel")).Text = "<img src='/file.png'>";
            }
        }
    }
