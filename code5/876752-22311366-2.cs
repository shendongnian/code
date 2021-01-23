    var package = new ExcelPackage(new FileInfo("sample.xlsx"));
 
    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
    var start = worksheet.Dimension.Start;
    var end = worksheet.Dimension.End;
    for (int row = start.Row; row <= end.Row; row++)
    { // Row by row...
        for (int col = start.Column; col <= end.Column; col++)
        { // ... Cell by cell...
            object cellValue = workSheet.Cells[row, col].Text; // This got me the actual value I needed.
        }
    }
