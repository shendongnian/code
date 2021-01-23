    public static void Export(System.Data.DataTable CrossoverDataTable)
    {
        // @@Parameters
        //
        // CrossoverDataTable DataTable :
        //     This is a data table containing information to be exported to our excel application.
        //     Requested as a way to circumvent sql injection opposed to the initial overload accepting only a string .commandtext.
        Application xls = new Application();
        xls.SheetsInNewWorkbook = 1;
        // Create our new excel application and add our workbooks/worksheets
        Workbook Workbook = xls.Workbooks.Add();
        Worksheet CrossoverPartsWorksheet = xls.Worksheets[1];
        
        // Hide our excel object if it's visible.
        xls.Visible = false;
        
        // Turn off screen updating so our export will process more quickly.
        xls.ScreenUpdating = false;
        
        // Turn off calculations if set to automatic; this can help prevent memory leaks.
        xls.Calculation = xls.Calculation == XlCalculation.xlCalculationAutomatic ? XlCalculation.xlCalculationManual : XlCalculation.xlCalculationManual;
        
        // Create an excel table and fill it will our query table.
        CrossoverPartsWorksheet.Name = "Crossover Data";
        CrossoverPartsWorksheet.Select();
        {
        
            // Create a row with our column headers.
            for (int column = 0; column < CrossoverDataTable.Columns.Count; column++)
            {
                CrossoverPartsWorksheet.Cells[1, column + 1] = CrossoverDataTable.Columns[column].ColumnName;
            }
            // Export our datatable information to excel.
            for (int row = 0; row < CrossoverDataTable.Rows.Count; row++)
            {
                for (int column = 0; column < CrossoverDataTable.Columns.Count; column++)
                {
                    CrossoverPartsWorksheet.Cells[row + 2, column + 1] = (CrossoverDataTable.Rows[row][column].ToString());
                }
            }
        }
        
        // Freeze our column headers.
        xls.Application.Rows["2:2"].Select();
        xls.ActiveWindow.FreezePanes = true;
        xls.ActiveWindow.DisplayGridlines = false;
        
        // Autofit our rows and columns.
        xls.Application.Cells.EntireColumn.AutoFit();
        xls.Application.Cells.EntireRow.AutoFit();
        
        // Select the first cell in the worksheet.
        xls.Application.Range["$A$2"].Select();
        
        // Turn off alerts to prevent asking for 'overwrite existing' and 'save changes' messages.
        xls.DisplayAlerts = false;
        // ******************************************************************************************************************
        // This section is commented out for now but can be enabled later to have excel sheets show on screen after creation.
        // ******************************************************************************************************************
        // Make our excel application visible
        xls.Visible = true;
        
        // Turn screen updating back on
        xls.ScreenUpdating = true;
        
        // Turn automatic calulation back on
        xls.Calculation = XlCalculation.xlCalculationAutomatic;
        // Release our resources.
        Marshal.ReleaseComObject(Workbook);
        Marshal.ReleaseComObject(CrossoverPartsWorksheet);
        Marshal.ReleaseComObject(xls);
    }
