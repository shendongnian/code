    using Microsoft.Office.Interop.Excel;
    
    private double? GetExcelCellValue(Range range, short? row, int col)
    {
        var cell = (range.Cells[row, col] as Range);
        //using null coalescing operator.
        return cell ?? cell.Value2;
    }
