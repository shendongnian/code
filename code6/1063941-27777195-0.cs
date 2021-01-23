    public void HightlightErrors()
    {
         Worksheet worksheet = (Worksheet)workbook.Sheets[1];
         Range last = worksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
         Range myRange = worksheet.get_Range("A1", last);
         int lastUsedRow = last.Row;
         int lastUsedColumn = last.Column;
         for (int i = 1; i < lastUsedColumn; i++) //Check each column to see if it is less than 5% filled.
         {
             Range currentColumn = worksheet.Columns[i];
             double a = application.WorksheetFunction.CountA(currentColumn);
             if ((a / lastUsedRow * 100) < 5)
             {
                  string columnChar = GetExcelColumnName(i);
                  string redCondition = "=COUNTA($"+ columnChar + "2)>0";
                  dynamic format = myRange.FormatConditions.Add(XlFormatConditionType.xlExpression, Formula1: redCondition);
                  format.Interior.Color = 0x0000FF;
             }
          }
          Marshal.ReleaseComObject(last);
          Marshal.ReleaseComObject(myRange);
    }   
