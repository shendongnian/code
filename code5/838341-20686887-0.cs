    foreach (DataListItem dli in DataList1.Items)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string productId = DataBinder.Eval(dli.DataItem, "ProductID").ToString();
            // Find the UserControl that's in this DataListItem
            ShopLine myShopLine = (ShopLine)dli.Findcontrol("ShopLine1");
            //Then extract the information you need from it
            TextBox tb = (TextBox)myShopLine.FindControl("QtyTextBox");
        }
    }
