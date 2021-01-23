                var dt = new DataTable();
    
                for (var row = 0; row < data.GetLength(0); ++row)
                {
                    for (var col = 0; col < data.GetLength(1); col++)
                    {
                        dt.Rows[row][col] = data[row, col];
                    }
                }
    
                Excel.Application oXL;
                Excel.Workbook oWB;
                Excel.Worksheet oSheet;
                //Excel.Range oRange;
    
                oXL = new Excel.Application();
    
                oXL.Visible = true;
                oXL.DisplayAlerts = false;
    
                oWB = oXL.Workbooks.Add(Missing.Value);
    
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = sheetName;
    
                var rowCount = 1;
    
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (var i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        if (rowCount == 2)
                        {
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        }
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }
    
                oSheet = null;
                oWB.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oWB = null;
                   
                oXL.Quit();
             
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
