    // Start a stopwatch to time the process
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    // Check if there are rows to process
    if (table != null && table.Rows.Count > 0) {
        // Determine the number of chunks
        int chunkSize = 100000;
        double chunkCountD = (double)table.Rows.Count / (double)chunkSize;
        int chunkCount = table.Rows.Count / chunkSize;
        chunkCount = chunkCountD > chunkCount ? chunkCount + 1 : chunkCount;
        // Instantiate excel
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        // Get a workbook
        Workbook wb = excel.Workbooks.Add();
                
        // Get a worksheet
        Worksheet ws = wb.Worksheets.Add();
        ws.Name = "Test Export";
        // Add column names to excel
        int col = 1;                
        foreach (DataColumn c in table.Columns) {
            ws.Cells[1, col] = c.ColumnName;
            col++;
        }
        // Build 2D array
        int i = 0;
        string[,] data = new string[table.Rows.Count, table.Columns.Count];
        foreach (DataRow row in table.Rows) {
            int j = 0;
            foreach (DataColumn c in table.Columns) {
                data[i, j] = row[c].ToString();
                j++;
            }
            i++;
        }
        int processed = 0;
        int data2DLength = data.GetLength(1);
        for (int chunk = 1; chunk <= chunkCount; chunk++) {
            if (table.Rows.Count - processed < chunkSize) chunkSize = table.Rows.Count - processed;            
            string[,] chunkData = new string[chunkSize, data2DLength];
            int l = 0;
            for (int k = processed; k < chunkSize + processed; k++) {
                for (int m = 0; m < data2DLength; m++) {
                    chunkData[l,m] = table.Rows[k][m].ToString();
                }
                l++;
            }
            // Set the range value to the chunk 2d array
            ws.Range[ws.Cells[2 + processed, 1], ws.Cells[processed + chunkSize + 1, data2DLength]].value = chunkData;
            processed += chunkSize;
        }
        // Auto fit columns and rows, show excel, save.. etc
        excel.Columns.AutoFit();
        excel.Rows.AutoFit();
        excel.Visible = true;                
    }
    // Stop the stopwatch and display the seconds elapsed
    sw.Stop();
    MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
