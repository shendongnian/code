    var package = new ExcelPackage(new FileInfo("sample.xlsx"));
 
    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
    var start = worksheet.Dimension.Start;
    var end = worksheet.Dimension.End;
    for (int j = start.Row; j <= end.Row; j++)
    { // Row by row...
        for (int i = start.Column; i <= end.Column; i++)
        { // ... Cell by cell...
            object cellValue = workSheet.Cells[i, j].Text; // This got me the actual value I needed.
        }
    }
