    private void myGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        DataGrid grid = (DataGrid)sender;
        object rowModel = e.Row.Item;
        int index = grid.Items.IndexOf(e.Row.Item);
        bool hideBottomBorder = false;
        if (index + 1 < grid.Items.Count)
        {
            var thisItem = rowModel as TheRowModel;
            var nextItem = grid.Items[index + 1] as TheRowModel;
            if (thisItem.Number == nextItem.Number)
            {
                hideBottomBorder = true;
            }
        }
        if (hideBottomBorder)
        {
            // hide bottom border
        }
        else
        {
            // show bottom border
        }
    }
