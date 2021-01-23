    var excelApp = new Microsoft.Office.Interop.Excel.Application();
    excelApp.Workbooks.Add();
    excelApp.Visible = true;
    var myFormat =
    Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1;
    excelApp.get_Range("A1", "B4").AutoFormat(myFormat, Type.Missing, 
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
