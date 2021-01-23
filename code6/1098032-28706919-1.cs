    private static void readFilteredCells()
    {
        Excel.Application xlApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
        Workbook xlBook = (Excel.Workbook)xlApp.ActiveWorkbook;
        Worksheet wrkSheet = xlBook.Worksheets[1];
        Range selection = xlApp.Selection;
        for (int rowIndex = selection.Row; rowIndex < selection.Row + selection.Rows.Count; rowIndex++)
        {
            if (wrkSheet.Rows[rowIndex].EntireRow.Height!=0)
            {
                // do something special
            }
        }
    }
