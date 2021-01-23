    using Microsoft.Office.Interop.Excel;
    using Application = Microsoft.Office.Interop.Excel.Application;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Application excelApplication = new Excel.Application
    {
        Visible = true,
        ScreenUpdating = true
    };
    
    _Workbook workbook = excelApplication.Workbooks.Open(@"C:\Temp\Book1.xlsx");
    _Worksheet sheet = workbook.Worksheets[1];
    Range range = sheet.Range["B1"];
    range.Formula = "Test";
    
    excelApplication.Quit();
