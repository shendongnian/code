    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    using System.IO;
    
    //Initial Declarations//
    Excel.Workbook destinationXlWorkBook;
    Excel.Worksheet destinationXlWorkSheet;
    Excel.Application destinationXlApp;
    object misValue = System.Reflection.Missing.Value;
    
    //Launch Excel App//
    destinationXlApp = new Excel.Application();
    
    //Load WorkBook in the opened Excel App//
    destinationXlWorkBook = destinationXlApp.Workbooks.Add(misValue);
    
    //Load worksheet-1 in the workbook//
    destinationXlWorkSheet =
     (Excel.Worksheet)destinationXlWorkBook.Worksheets.get_Item(1);
    
    //Set Text-Wrap for all rows true//
    destinationXlWorkSheet.Rows.WrapText = true;
    
    //Or, set it for specific rows//
    destinationXlWorkSheet.Rows[3].WrapText = true;
    destinationXlWorkSheet.Rows[5].WrapText = true;
    
    //Edit individual cells//
     xlWorkSheet.Cells[1, 1] = "ID";                  
     xlWorkSheet.Cells[1, 2] = "Name";
     xlWorkSheet.Cells[2, 1] = "1";
     xlWorkSheet.Cells[2, 2] = "One";
     xlWorkSheet.Cells[3, 1] = "2";
     xlWorkSheet.Cells[3, 2] = "Two";
    
    
    //Save and close the Excel//
    destinationXlWorkBook.SaveAs("C:\\Users\\UtkarshSinha\\Documents\\SAP\\text.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                
    //Start quitting and closing Excel//
    destinationXlWorkBook.Close(true, misValue, misValue);
    destinationXlApp.Quit();
    Marshal.ReleaseComObject(destinationXlWorkSheet);
    Marshal.ReleaseComObject(destinationXlWorkBook);
    Marshal.ReleaseComObject(destinationXlApp);
