    var xlApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook book = 
    xlApp.Workbooks.Open(@"E:\\excelsheet\\incomschedule.xlsx");
    xlApp.DisplayAlerts = false;
    Worksheet worksheet = (Worksheet)book.Worksheets[2];
    worksheet.Delete();
    book.Worksheets.Add();
    xlApp.DisplayAlerts = true;
    book.Save();
    book.Close();
