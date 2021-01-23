    protected void rptConfirmOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          var dataItem = e.Item.DataItem as YOUR_ENTITY_TYPE;
          Debug.Assert(5 == dataItem.Quantity);
        }
    }
