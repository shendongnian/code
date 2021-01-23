    protected void radGridTranslation_ItemCommand(object _sender, GridCommandEventArgs _event)
    {
        if (_event.Item is GridDataItem)
        {
            if (_event.CommandName == myRadGrid.UpdateCommandName)
            {
                GridDataItem l_dataItem = (GridDataItem)_event.Item;
                Dictionary<string, string> l_gridUpdatedItemList = new Dictionary<string, string>();
                l_dataItem.ExtractValues(l_gridUpdatedItemList);
                foreach (KeyValuePair<string, string> l_updatedItemWithColumn in l_gridUpdatedItemList)
                {
                    // Key = The column name
                    // Value = The cell value
                }
            }
        }
    }
