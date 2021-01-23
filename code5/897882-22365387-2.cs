    public static void ReadExcel()
        {
            var excelObject = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook;
            Worksheet worksheet;
            Range range;
            workbook = excelObject.Workbooks.Open("C:\\Book1.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var sheet = workbook.Worksheets;
            worksheet = (Worksheet)sheet.get_Item(1);
            var last = worksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            var usedRange = worksheet.get_Range("B1", last);
            var lastNumber = 0;
            for (var i = 1; i <= usedRange.Count; i++)
            {
                range = (Range)worksheet.Cells[i, 1];
                var strData = "";
                try
                {
                    strData = range.Value2.ToString();
                    if (Regex.IsMatch(strData, @"^[a-zA-Z]+$"))
                    {
                        lastNumber++;
                    }
                    else
                    {
                        var temp = 0;
                        int.TryParse(range.Value2.ToString(), out temp);
                        if (temp > lastNumber)
                            lastNumber = temp;
                    }
                }
                catch (Exception ee)
                {
                    if (range.Value2 == null)
                    {
                        if (lastNumber == 0)
                            lastNumber++;
                        range.Value2 = lastNumber;
                    }
                }
            }
            workbook.SaveAs("C:\\tempBook.xls", true);
            workbook.Close();
        }
