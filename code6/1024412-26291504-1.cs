    private void EditButton_InsideDataGrid_Click(object sender, RoutedEventArgs e)
    {
        int colIndex = 0;
        int rowIndex = 0;
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        while (dep != null && !(dep is DataGridCell))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        if (dep == null)
            return;
        DataGridRow row = null;
        if (dep is DataGridCell)
        {
            colIndex = ((DataGridCell)dep).Column.DisplayIndex;
            while (dep != null && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            row = (DataGridRow)dep;
            rowIndex = FindRowIndex(row);
        }
        while (dep != null && !(dep is DataGrid))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        if (dep == null)
            return;
        DataGrid dg = (DataGrid)dep;
        if (row != null)
        {
            if (row.IsEditing)
                dg.CommitEdit(DataGridEditingUnit.Row, true);
            else
            {
                dg.CurrentCell = new DataGridCellInfo(dg.Items[rowIndex], dg.Columns[0]);
                dg.BeginEdit();
            }
        }
    }
