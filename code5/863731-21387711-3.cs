    protected void dgMyGrid_ItemBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Cells["MyCol"].CssClass = "MyCssClass";
            }
    }
