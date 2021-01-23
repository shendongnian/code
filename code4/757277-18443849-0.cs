    void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        checkRow(e.Row);
    }
    
    private void checkRow(DataGridRow dgRow)
    {
        if (dgRow == null)
            return;
    
        var item = dgRow.Item as MyItemClass;
        if (item != null && item.BoolProperty)
        {
            ...
        }
        else
        {
            ...
        }
    }
