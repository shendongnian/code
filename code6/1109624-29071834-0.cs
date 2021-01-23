    string mySheet = @"E:\7.xlsx";
    var excelApp = new Excel.Application();
    excelApp.Visible = true;
    Excel.Workbook sheet = excelApp.Workbooks.Open(mySheet,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, true);
