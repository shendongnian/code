    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var editItem = e.Item as GridEditFormItem;
        if (e.Item is GridDataItem && !e.Item.IsInEditMode)
        {
            GridDataItem item = (GridDataItem)e.Item;
            bool success,deleted;
            bool.TryParse(item["deleted"].Text, out success);
            if (success)
            {
                deleted = bool.Parse(item["deleted"].Text);
                if (deleted)
                {
                    item.Display = false;
                }
            }
        }
    }
