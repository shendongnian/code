        public class PivotSheetProp
        {
            public int ID { get; set; }
            public string SheetName { get; set; }
            public int StartColumnIndex { get; set; }
            public int StartRowIndex { get; set; }
        }
        public static void ReadExistingExcel(DataSet ds, List<PivotSheetProp> accPivotList, string path)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel.Workbook mWorkBook;
            Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
            Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            try
            {
                //Get all the sheets in the workbook
                mWorkSheets = mWorkBook.Worksheets;
                int tblCount = 0;
                foreach (var v in accPivotList)
                {
                    //Get the allready exists sheet
                    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item(v.SheetName);
                    //Set alignment and font size
                    mWSheet1.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    mWSheet1.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    mWSheet1.Cells.Font.Size = 11;
                    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                    int colCount = range.Columns.Count;
                    int rowCount = range.Rows.Count;
                    int startRowCount = v.StartRowIndex;
                    if (startRowCount != 0)
                    {
                        rowCount = startRowCount;
                    }
                    for (int index = 1; index <= ds.Tables[tblCount].Rows.Count; index++)
                    {
                        int cellIndex = v.StartColumnIndex;
                        foreach (object tc in ds.Tables[tblCount].Rows[index - 1].ItemArray)
                        {
                            mWSheet1.Cells[rowCount + index, cellIndex++] = tc.ToString();
                        }
                    }
                    tblCount++;
                }
                foreach (Microsoft.Office.Interop.Excel.Worksheet pivotSheet in mWorkSheets)
                {
                    Microsoft.Office.Interop.Excel.PivotTables pivotTables = pivotSheet.PivotTables();
                    int pivotTablesCount = pivotTables.Count;
                    if (pivotTablesCount > 0)
                    {
                        for (int i = 1; i <= pivotTablesCount; i++)
                        {
                            pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
                        }
                    }
                }
                ///For 97-03
                //mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                //Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value);
                //mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
                ///For 2007
                mWorkBook.SaveAs(path);
                mWorkBook.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in updating excel file.\r\nFile name [" + path + "].\r\n\r\nMessage :- " + ex.Message, 
                    "Repeat report", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            mWSheet1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
