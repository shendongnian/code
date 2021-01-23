    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label myLabel = e.Item.FindControl("MyLabel") as Label;
            YourItemObject itemObject = e.Item.DataItem as YourItemObject;
            myLabel.Text = itemObject.SomeAttribute;
        }
    }
