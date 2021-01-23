    private void dataPaths_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
    {
       IList<DataGridCellInfo> cells = (sender as DataGrid).SelectedCells;
    
       foreach (DataGridCellInfo cell in cells)
           e.ClipboardRowContent.Add(new DataGridClipboardCellContent(e.Item, cell.Column, null));
    
       //or write out to a log
       foreach (var row in e.ClipboardRowContent)
          Console.WriteLine(row.Item.toString()); 
    }
