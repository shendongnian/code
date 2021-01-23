            using (var file = new FileStream(workbookLocation, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                var sheet = workbook.GetSheetAt(0);
                for (int rowNo = 0; rowNo <= sheet.LastRowNum; rowNo++)
                {
                    var row = sheet.GetRow(rowNo);
                    if (row == null) // null is when the row only contains empty cells 
                        continue;
                    for (int cellNo = 0; cellNo <= row.LastCellNum; cellNo++)
                    {
                        var cell = row.GetCell(cellNo);
                        if (cell == null) // null is when the cell is empty
                            continue;
                        var topBorderStyle = cell.CellStyle.BorderTop;
                        if (topBorderStyle != BorderStyle.None)
                        {
                            MessageBox.Show(string.Format("Cell row: {0} column: {1} has TopBorder: {2}", cell.Row.RowNum, cell.ColumnIndex, topBorderStyle));
                        }
                    }
                }
            }
