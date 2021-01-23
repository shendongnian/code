    Here is the code
    
     Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
    
     Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)xla.ActiveSheet;       
