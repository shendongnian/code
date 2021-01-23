    dg.CurrentCell = new DataGridCellInfo(dg.Items[rowIndex], dg.Columns[0]);
    dg.BeginEdit();
    for (int column = 0; column <= dg.Columns.Count - 1; column++)
    {
        if (!(GetDataGridCell(new DataGridCellInfo(dg.Items[rowIndex], dg.Columns[column])).IsReadOnly))
        {
            GetDataGridCell(new DataGridCellInfo(dg.Items[rowIndex], dg.Columns[column])).IsEditing = true;
        }
    }
    
    foreach (DataGridRow r in rows)
    {
        if (!(r.IsEditing))
        {
            r.IsEnabled = false;
        }
    }
