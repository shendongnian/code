    private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
    private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
    private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
    private static Microsoft.Office.Interop.Excel.Application oXL;
    public static void ReadExistingExcel()
    {
       string path = @"C:\Tool\Reports1.xls";
       oXL = new Microsoft.Office.Interop.Excel.Application();
       oXL.Visible = true;
       oXL.DisplayAlerts = false;
       mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
       //Get all the sheets in the workbook
       mWorkSheets = mWorkBook.Worksheets;
       //Get the allready exists sheet
       mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
       Microsoft.Office.Interop.Excel.Range range= mWSheet1.UsedRange;
       int colCount = range.Columns.Count;
       int rowCount= range.Rows.Count;
       for (int index = 1; index < 15; index++)
       {
          mWSheet1.Cells[rowCount + index, 1] = rowCount +index;
          mWSheet1.Cells[rowCount + index, 2] = "New Item"+index;
       }
       mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
       Missing.Value, Missing.Value, Missing.Value,    Missing.Value,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
    Missing.Value, Missing.Value, Missing.Value,
    Missing.Value, Missing.Value);
       mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
       mWSheet1 = null;
       mWorkBook = null;
       oXL.Quit();
       GC.WaitForPendingFinalizers();
       GC.Collect();
       GC.WaitForPendingFinalizers();
       GC.Collect();
    } 
