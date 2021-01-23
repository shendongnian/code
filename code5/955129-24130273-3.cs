    // Get an excel instance
    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
    // Get a workbook
    Workbook wb = excel.Workbooks.Add();
    // Get a worksheet
    Worksheet ws = wb.Worksheets.Add();
    ws.Name = "Test Export";
    // Add column names to the first row
    int col = 1;
    foreach (DataColumn c in table.Columns) {
        ws.Cells[1, col] = c.ColumnName;
        col++;
    }
    // Create a 2D array with the data from the table
    int i = 0;
    string[,] data = new string[table.Rows.Count, table.Columns.Count];
    foreach (DataRow row in table.Rows) {                
        int j = 0;
        foreach (DataColumn c in table.Columns) {
            data[i,j] = row[c].ToString();
            j++;
        }
        i++;            
    }                   
    // Set the range value to the 2D array
    ws.Range[ws.Cells[2, 1], ws.Cells[table.Rows.Count + 1, table.Columns.Count]].value = data;
    // Auto fit columns and rows, show excel, save.. etc
    excel.Columns.AutoFit();
    excel.Rows.AutoFit();
    excel.Visible = true;
