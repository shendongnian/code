        public void ExportToExcel(DataTable dataTable, String pathToSave)
        {
            // Create the Excel Application object
            var excelApp = new ApplicationClass();
            // Create a new Excel Workbook
            Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
            int sheetIndex = 0;
            // Copy the DataTable to an object array
            var rawData = new object[dataTable.Rows.Count + 1, dataTable.Columns.Count];
            // Copy the column names to the first row of the object array
            for (var col = 0; col < dataTable.Columns.Count; col++)
            {
                rawData[0, col] = dataTable.Columns[col].ColumnName;
            }
            // Copy the values to the object array
            for (var col = 0; col < dataTable.Columns.Count; col++)
            {
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    rawData[row + 1, col] = dataTable.Rows[row].ItemArray[col];
                }
            }
            // Calculate the final column letter
            string finalColLetter = string.Empty;
            const string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;
            if (dataTable.Columns.Count > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (dataTable.Columns.Count - 1) / colCharsetLen - 1, 1);
            }
            finalColLetter += colCharset.Substring((dataTable.Columns.Count - 1) % colCharsetLen, 1);
            // Create a new Sheet
            var excelSheet = (Worksheet)excelWorkbook.Sheets.Add(excelWorkbook.Sheets.Item[++sheetIndex], Type.Missing, 1, XlSheetType.xlWorksheet);
            excelSheet.Name = dataTable.TableName;
            // Fast data export to Excel
            var excelRange = string.Format("A1:{0}{1}", finalColLetter, dataTable.Rows.Count + 1);
            excelSheet.Range[excelRange, Type.Missing].Value2 = rawData;
            // Mark the first row as BOLD and BLUE
            var headerColumnRange = (Range)excelSheet.Rows[1, Type.Missing];
            headerColumnRange.Font.Bold = true;
            headerColumnRange.Font.Color = 0xFF0000;
            headerColumnRange.EntireColumn.AutoFit();
            // Save and Close the Workbook
            excelWorkbook.SaveAs(pathToSave, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;
            // Release the Application object
            excelApp.Quit();
            excelApp = null;
            // Collect the unreferenced objects
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
