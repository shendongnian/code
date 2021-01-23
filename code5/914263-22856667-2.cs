    addModule();
    Worksheet ws = Globals.ThisWorkbook.ActiveSheet as Worksheet;
    Workbook wb = ws.Parent as Workbook;
    Microsoft.Office.Interop.Excel.Application app = 
                             wb.Parent as Microsoft.Office.Interop.Excel.Application;
    app.OnKey("^e", "CentreText");
