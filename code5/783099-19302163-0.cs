           protected void xlsWorkBook()
           {
                Excel.Application oXL;
                Excel.Workbook oWB;
                Excel.Worksheet oSheet;
                // Start Excel and get Application object.
                oXL = new Excel.Application();
                // Set some properties
                //oXL.Visible = false;
                oXL.DisplayAlerts = false;
                // Get a new workbook.
                oWB = oXL.Workbooks.Add(Missing.Value);
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                UpdataDataToExcelSheets(oSheet,"sheet name",dataGrid1,true);
                // Save the sheet and close
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel File|*.xlsx";
                saveFileDialog1.Title = "Save an Excel File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    oWB.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                              Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
                }
                oWB.Close();
                oXL.Quit();
                //// Clean up
                if (oSheet != null)
                {
                    Marshal.FinalReleaseComObject(oSheet);
                    oSheet = null;
                }
                if (oWB != null)
                {
                    Marshal.FinalReleaseComObject(oWB);
                    oWB = null;
                }
                if (oXL.Workbooks != null)
                {
                    Marshal.FinalReleaseComObject(oXL.Workbooks);
                }
                if (oXL != null)
                {
                    Marshal.FinalReleaseComObject(oXL);
                    oXL = null;
                }
                //// NOTE: When in release mode, this does the trick
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
          }
           private void UpdataDataToExcelSheets(Excel.Worksheet oSheet,string sheetName, DataGridView  dataGridExport,bool isColorCells)
        {
            Excel.Range oRange;
            oSheet.Name = sheetName;
            for (int k = 1; k <= dataGridExport.Columns.Count; k++)
            {
                oSheet.Cells[1, k] = dataGridExport.Columns[k - 1].Name;
                ((dynamic)oSheet.Cells[1, k]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue);
            }
            for (int i = 1; i <= dataGridExport.Rows.Count; i++)
            {
                for (int k = 1; k <= dataGridExport.Rows[i - 1].Cells.Count; k++)
                {
                    if (Convert.ToString(dataGridExport.Rows[i - 1].Cells[k - 1].Value) != string.Empty)
                    {
                        oSheet.Cells[i + 1, k] = dataGridExport.Rows[i - 1].Cells[k - 1].Value;
                    }
                    if ((isColorCells)&&(dataGridExport.Rows[i - 1].Cells[k - 1].Style.BackColor.ToArgb() != 0))
                    {
                        ((dynamic)oSheet.Cells[i + 1, k]).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(dataGridExport.Rows[i - 1].Cells[k - 1].Style.BackColor.ToArgb()));
                    }
                }
            }
            oRange = oSheet.Range[oSheet.Cells[1, 1],
            oSheet.Cells[dataGridExport.Rows.Count - 1, dataGridExport.Columns.Count + 1]];
            oRange.EntireColumn.AutoFit();
            if (oRange != null)
            {
                Marshal.FinalReleaseComObject(oRange);
                oRange = null;
            }
        }
