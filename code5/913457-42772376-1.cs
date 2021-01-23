    using System.Linq;
    
    DataTable xDataTable = new DataTable();
    DataObject XClipboardDat = (DataObject)Clipboard.GetDataObject();
                if (XClipboardDat.GetDataPresent(DataFormats.Text))
                {
                    string[] pastedRows = Regex.Split(XClipboardDat.GetData(DataFormats.Text).ToString(), @"[\r\n]+").Where(y => !string.IsNullOrEmpty(y.ToString())).ToArray();
                IEnumerable<string[]> XDatRowCol = pastedRows.Select(xRow => Regex.Split(xRow, @"[\t]+").Where(y => !string.IsNullOrEmpty(y.ToString())).ToArray());
                int ColNum = XDatRowCol.Select(dudu => dudu.Length).ToArray().Max<int>();
                
                for (int i = 0; i < ColNum; i++) { xDataTable.Columns.Add(); }
                foreach(string[] XDatRow in XDatRowCol) { xDataTable.Rows.Add(XDatRow); }
                
                dataGridView2.DataSource = xDataTable;
            }
