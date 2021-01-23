    public static List<System.Drawing.Point> GetSelectedCells()
        {
            //We will use this to hold column and row coordinates for cells
            List<System.Drawing.Point> value = new List<System.Drawing.Point>();
            try
            {
                Microsoft.Office.Interop.Word.Range range = Globals.ThisAddIn.Application.Selection.Range; 
                if (range.Tables.Count > 0)
                {
                    Table tempTable = range.Tables[1];
                    float[,] backupTable = new float[range.Tables[1].Rows.Count + 1, range.Tables[1].Columns.Count + 1];
                    for (int i = 1; i <= tempTable.Rows.Count; i++)
                    {
                        for (int j = 1; j <= tempTable.Rows[i].Cells.Count; j++)
                            backupTable[i, j] = tempTable.Rows[i].Cells[j].Range.Font.Size;
                    }
                    Globals.ThisAddIn.Application.Selection.Font.Size = 1;
                    foreach (Row row in range.Tables[1].Rows)
                    {
                        foreach (Cell cell in row.Cells)
                        {
                            if (cell.Range.Font.Size == 1)
                            {
                                System.Drawing.Point point = new System.Drawing.Point();
                                point.X = cell.RowIndex;
                                point.Y = cell.ColumnIndex;
                                value.Add(point);
                            }
                        }
                    }
                    for (int i = 1; i <= tempTable.Rows.Count; i++)
                    {
                        for (int j = 1; j <= tempTable.Rows[i].Cells.Count; j++)
                            tempTable.Rows[i].Cells[j].Range.Font.Size = backupTable[i, j];
                    }
                    Marshal.ReleaseComObject(tempTable);
                }
            }
            catch(Exception)
            {
               //This exception can be used to handle Exception that occurs when there are merged cells in the     table.
            }
            return value;
        }
