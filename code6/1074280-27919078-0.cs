                    if ((range.Cells[rowCount, columnCount] as Excel.Range).Value != null)
                    {
                        rowEntity.ColumnValues.Add((range.Cells[rowCount, columnCount] as Excel.Range).Value.ToString());
                    }
                    else
                        rowEntity.ColumnValues.Add(""); //just add this line. keeps the blank cell as created with empty string
