    private void CellClicked(object sender, MouseButtonEventArgs e)
    {
        var cell = sender as DataGridCell; //your cell
        xamlAllocateAudit details = new xamlAllocateAudit();
        //do some sort of passing of data like:
        //details.DataContext = cell.Content;
        details.Show();
    }
