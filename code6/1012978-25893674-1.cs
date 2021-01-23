    using Excel = Microsoft.Office.Interop.Excel;
    
    [snip]
    Excel.Application exApp = new Excel.Application();
    Excel.Workbook exWbk = exApp.Workbooks.Open(@"c:\path\to\your\workbook.xls");
    Boolean signed = exWbk.VBASigned;
    // When finished make sure we release the Interop COM objects we used
    Marshal.ReleaseComObject(exWbk);
    Marshal.ReleaseComObject(exApp); 
 
