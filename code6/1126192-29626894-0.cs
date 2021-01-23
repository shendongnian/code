    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open("D:\\Book1.xlsx"); 
    
    String[] excelSheets = new String[excelBook.Worksheets.Count];
        int i = 0;
        foreach(Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)    
        {
          excelSheets[i] = wSheet.Name;
          i++;
        }
