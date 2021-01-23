    Microsoft.Office.Tools.Excel.Worksheet TheSheet;
    private void PublishToSheet( int totalRows, int maxColumns, ref string[,] OutputArray )
    {
        Excel.Range Range = TheSheet.Range["A1", TheSheet.Cells[totalRows, maxColumns]];
        Range.NumberFormat = "@";
        Range.Value2 = OutputArray;
        LastRow = totalRows;
        LastColumn = maxColumns;
        
    }
