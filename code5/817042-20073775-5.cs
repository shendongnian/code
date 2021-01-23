    private void CellClicked(object sender, MouseButtonEventArgs e)
    {
        var cell = (DataGridCell)((FrameworkElement)sender).Parent;
        var rowData = cell.DataContext; //DataContext for the row containing the current cell
        xamlAllocateAudit window = new xamlAllocateAudit
        {
            DataContext = rowData
        }
        window.Show();
    }
