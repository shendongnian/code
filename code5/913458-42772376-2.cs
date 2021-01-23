    using System.Linq;
    
    DataTable xDataTable = new DataTable();
    DataObject XClipboardDat = (DataObject)Clipboard.GetDataObject();
    if (XClipboardDat.GetDataPresent(DataFormats.Text))
    {
        string[] XClipboardRows = Regex.Split(XClipboardDat.GetData(DataFormats.Text).ToString(), @"[\r\n]+").Where(y => !string.IsNullOrEmpty(y.ToString())).ToArray();
        IEnumerable<string[]> XDatRowCol = XClipboardRows.Select(xRow => Regex.Split(xRow, @"[\t]+").Where(y => !string.IsNullOrEmpty(y.ToString())).ToArray());
        int ColNum = XDatRowCol.Select(XDatRow => XDatRow.Length).ToArray().Max<int>();
                
        for (int i = 0; i < ColNum; i++) { xDataTable.Columns.Add(); }
        foreach(string[] XDatRow in XDatRowCol) { xDataTable.Rows.Add(XDatRow); }
                
        dataGridView2.DataSource = xDataTable;
     }
