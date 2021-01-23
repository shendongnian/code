    foreach (var column in gridView1.Columns.OfType<DevExpress.XtraGrid.Columns.GridColumn>())
    {
        if (column.FieldName == "MemberToBeHidden")
        {
            // Just hide it by default, user can still choose to show it later
            column.Visible = false;
    
            // Or completely remove from the grid
            gridView1.Columns.Remove(column);
        }
    }
