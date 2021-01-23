    private void CellClicked(object sender, MouseButtonEventArgs e)
    {
        var cell = (DataGridCell)((FrameworkElement)sender).Parent;
        //CAST TO CORRECT CLASS HERE
        var rowData = ((YOUR CLASS)cell.DataContext).ToBeAudited; //DataContext for the row containing the current cell
        xamlAllocateAudit window = new xamlAllocateAudit
        {
            DataContext = rowData
        }
        window.Show();
    }
