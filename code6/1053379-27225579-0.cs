    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelInterop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application xlApp = null;
                Excel.Workbook xlWorkBook = null;
    
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet newWorksheet = null;
                newWorksheet = (Excel.Worksheet)xlApp.Application.Worksheets.Add();
                xlApp.ScreenUpdating = false;
                Excel.Range excelRange = newWorksheet.UsedRange;
    
                // Column 1
                excelRange.Cells.set_Item(1, 1, "Column 1");
    
                // Column 1 Data
                excelRange.Cells.set_Item(2, 1, "sss");
    
                // Column 2
                excelRange.Cells.set_Item(1, 2, "Column 2");
    
                // Column 1 Data
                excelRange.Cells.set_Item(2, 2, "ttt");
    
    
                // Save it as .xls
                newWorksheet.SaveAs("D:\\ExcelInterop", Excel.XlFileFormat.xlExcel7);
    
                // Clean up
                xlWorkBook.Close();
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
    
            }
        }
    }
