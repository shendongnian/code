    if (!e.IsGetData || e.Column.FieldName != "colCalcQty")
        return;
    var rowHandle = gridView1.GetRowHandle(e.ListSourceRowIndex);
    var view = gridView1.GetDetailView(rowHandle, 0);
    int quantity = 0;
    if (view == null)
    {
        var gridItem = (GridItemModel)e.Row;
        foreach (var gridItemInventory in gridItem.Inventory)
            quantity += gridItemInventory.Quantity;
    }
    else
        foreach (var row in view.DataController.GetAllFilteredAndSortedRows())
        {
            var gridItemInventory = (GridItemInventoryModel)row;
            quantity += gridItemInventory.Quantity;
        }
    
    e.Value = quantity;
