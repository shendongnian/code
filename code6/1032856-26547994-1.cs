    using Excel = Microsoft.Office.Interop.Excel;
    using ExcelDna.Integration;
    
    // Get the currect application instance
    Excel.Application xlapp = (Excel.Application)ExcelDnaUtil.Application;
    
    // Get active workbook
    Excel.Workbook wbook = xlapp.ActiveWorkbook;
