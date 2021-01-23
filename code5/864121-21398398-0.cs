                Excel._Application XL = new Excel.Application();
                Excel._Workbook WB;
                Excel._Worksheet SH;
                WB = XL.Workbooks.Open(@filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                SH = (Excel.Worksheet)WB.Worksheets.get_Item(1);
                    lastUsedRow = SH.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
    
                    for (int i = 1; i < lastUsedRow; i++)
                    {
                        if (GetCell(SH, i, 2) == "")
                        {
                              //Do your code
                        }
                    }
    
            public static string GetCell(Excel._Worksheet worksheet, int row, int column)
            {
                Excel.Range range = worksheet.Cells[row, column] as Excel.Range;
                if (range == null || range.Value2 == null)
                {
                    return string.Empty;
                }
                return range.Value2.ToString();
            }
    
            private static void ReleaseComObject(object activeXObject)
            {
                if (activeXObject != null)
                {
                    Marshal.ReleaseComObject(activeXObject);
                    activeXObject = null;
                }
            }
