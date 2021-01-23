    using Microsoft.Office.Interop.Excel;
    
    string path = "C:\\Projects\\ExcelSingleValue\\Test.xlsx ";
    
    Application excel = new Application();
    Workbook wb = excel.Workbooks.Open(path);
    Worksheet excelSheet = wb.ActiveSheet;
    //Read the first cell
    string test = excelSheet.Cells[1, 1].Value.ToString();
    wb.Close();
