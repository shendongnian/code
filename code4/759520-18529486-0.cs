     Excel.Range excelCell = xlWorksheet.UsedRange;
     Excel.Range oRng = xlWorksheet.get_Range("A1").SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);
            int lLastCol = oRng.Column;
            int colCount = excelCell.Columns.Count;
            int firstEmptyCols = lLastCol - colCount;
