    public object[,] GetNonContiguousVisibleRowsData(Excel.Worksheet sheet, string noncontiguous_address)
    {
        // Add a new worksheet
        Excel.Workbook book = (Excel.Workbook)sheet.Parent;
        Excel.Sheets sheets = book.Sheets;
        Excel.Worksheet tempSheet = (Excel.Worksheet)sheets.Add();
        Excel.Range cellA1 = tempSheet.get_Range("A1");
    
        // Get only the visible cells
        Excel.Range nonContiguousRange = sheet.get_Range(noncontiguous_address);
        Excel.Range visibleSourceRange = nonContiguousRange.SpecialCells(Excel.XlCellType.xlCellTypeVisible);
    
        // Copying the visible cells will result in a contiguous range in tempSheet
        visibleSourceRange.Copy(cellA1);
    
        // Get the contiguous range and copy the cell value.
        Excel.Range contiguousRange = tempSheet.UsedRange;
        object[,] data = (object[,])contiguousRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
    
        // Release all COM objects from temp sheet, e.g.:
        // System.Runtime.InteropServices.Marshal.ReleaseComObject(contiguousRange);
        // contiguousRange = null;
    
        tempSheet.Delete();
    
        // release all other COM objects
    
        return data;
    }
