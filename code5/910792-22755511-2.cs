    protected void lvDetNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var hiddenFld = e.Item.FindControl("HFcari") as HiddenFiled;
            string value = hiddenFld.Value();
            // ...
        }
    }
