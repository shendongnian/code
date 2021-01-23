                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excelApp.Workbooks.Open(@"c:\folder\excelfile.xlsx", Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing);
                excelApp.DisplayAlerts = false;
                var ws = wb.Worksheets;
                var worksheet = (Worksheet)ws.get_Item("sheetname");
                Range range = worksheet.UsedRange;
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                Range startCell = worksheet.Cells[1, 1];
                Range endCell = worksheet.Cells[rows, cols];
                worksheet.Range[startCell, endCell].Replace("'", "", MatchCase: false);
                wb.Close(true);
                excelApp.Quit();
