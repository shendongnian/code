    using Workbook = Microsoft.Office.Interop.Excel.Workbook;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Worksheet ws = Globals.ThisAddIn.Application.ActiveSheet;
    Excel.Range activeCell = Globals.ThisAddIn.Application.ActiveCell;
