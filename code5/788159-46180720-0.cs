    public int clipboardcalledcnt { get; set; } //CopyingRowClipboardContent invoked count
    private void myDataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
    {
        PathInfo cellpath = new PathInfo(); //a custom class to hold path info
        string path = string.Empty;
    
    DataGrid dgdataPaths = (DataGrid)sender;
    int rowcnt = dgdataPaths.SelectedItems.Count;
    cellpath = (PathInfo)e.Item;
    
    path = "Row #"+ clipboardcalledcnt +" Len="+ cellpath.Length.ToString() + ", path=" + cellpath.Path;
    e.ClipboardRowContent.Clear();
    if (clipboardcalledcnt == 0) //add header to clipboard paste
        e.ClipboardRowContent.Add(new DataGridClipboardCellContent("", null, "--- Clipboard Paste ---\t\t\n")); // \t cell divider, repeat (number of cells - 1)
    
    clipboardcalledcnt++;
    e.ClipboardRowContent.Add(new DataGridClipboardCellContent(path, null, path));
    
    if (clipboardcalledcnt == rowcnt)
        clipboardcalledcnt = 0;
}
      
