    public static void ExportToExcel(DataTable dt)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = null;
                try
                {
                    // instantiating the excel application class
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                    currentWorksheet.Columns.ColumnWidth = 18;
    
    
                    if (dt.Rows.Count > 0)
                    {
                        currentWorksheet.Cells[1, 1] = DateTime.Now.ToString("s");
                        int i = 1;
                        foreach (DataColumn dtColumn in dt.Columns)
                        {
                            // Excel work sheet indexing starts with 1
                            currentWorksheet.Cells[2, i] = dtColumn.Name;
                            ++i;
                        }
                        Microsoft.Office.Interop.Excel.Range headerColumnRange = currentWorksheet.get_Range("A2", "G2");
                        headerColumnRange.Font.Bold = true;
                        headerColumnRange.Font.Color = 0xFF0000;
                        //headerColumnRange.EntireColumn.AutoFit();
                        int rowIndex = 0;
                        for (rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                        {
                            DataRow row = dt.Rows[rowIndex];
                            for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                            {
                                currentWorksheet.Cells[rowIndex + 3, cellIndex + 1] = row.Cells[cellIndex].Value;
                            }
                        }
                        Microsoft.Office.Interop.Excel.Range fullTextRange = currentWorksheet.get_Range("A1", "G" + (rowIndex + 1).ToString());
                        fullTextRange.WrapText = true;
                        fullTextRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    }
                    else
                    {
                        string timeStamp = DateTime.Now.ToString("s");
                        timeStamp = timeStamp.Replace(':', '-');
                        timeStamp = timeStamp.Replace("T", "__");
                        currentWorksheet.Cells[1, 1] = timeStamp;
                        currentWorksheet.Cells[1, 2] = "No error occured";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                    }
                }
            }
