    List<string> ReadDropDownValues(Excel.Workbook xlWorkBook, Excel.Range dropDownCell)
    {
        List<string> result = new List<string>();
    
        string formulaRange = dropDownCell.Validation.Formula1;
        string[] formulaRangeWorkSheetAndCells = formulaRange.Substring(1, formulaRange.Length - 1).Split('!');
        string[] splitFormulaRange = formulaRangeWorkSheetAndCells[1].Split(':');
        Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(formulaRangeWorkSheetAndCells[0]);
    
        Excel.Range valRange = (Excel.Range)xlWorkSheet.get_Range(splitFormulaRange[0], splitFormulaRange[1]);
        for (int nRows = 1; nRows <= valRange.Rows.Count; nRows++)
        {
            for (int nCols = 1; nCols <= valRange.Columns.Count; nCols++)
            {
                Excel.Range aCell = (Excel.Range)valRange.Cells[nRows, nCols];
                if (aCell.Value2 != null)
                {
                    result.Add(aCell.Value2.ToString());
                }
            }
        }
    
        return result;
    }
