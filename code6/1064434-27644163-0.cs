            Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.UsedRange.Columns[columnIndex, Type.Missing];
            range.Select();
            range.Activate();
            range.AutoFilter(1, val, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlFilterValues, Type.Missing, true);
            Range visibleCells = range.SpecialCells(
                               Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible,
                               Type.Missing);
            foreach (Range area in visibleCells.Areas)
            {
                foreach (Range row in area.Rows)
                {
                    Range filteredCell = (Range)row.Cells[1, 1];
                    if (filteredCell == null || filteredCell.Value2.ToString() != val)
                        continue;
                    int index = row.Row;
                    //Console.WriteLine("Index:" + index);
                    int columnNo = workSheet.UsedRange.Columns.Count;
                    workSheet.Cells[index, columnNo] = "Add Comments";
                }
            }
