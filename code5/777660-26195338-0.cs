    using Microsoft.Office.Interop.Excel;
    
    string path = "C:\\Projects\\ExcelSingleValue\\Test.xlsx ";
    
    Application excel = new Application();
    Workbook wb = excel.Workbooks.Open(path);
    Worksheet excelSheet = wb.ActiveSheet;
    string test = excelSheet.Cells[3, 2].Value.ToString();
    wb.Close();
