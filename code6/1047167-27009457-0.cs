    public void exportExcel(string path, DataGridView dgv)
                {
                   try
                    {
                         Microsoft.Office.Interop.Excel._Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                         ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 10;
         
         
                         for (int j = 0; j < dgv.ColumnCount; j++)
                         {
                             ExcelApp.Cells[1, j + 1] = dgv.Columns[j].HeaderText;
                         }
                         Microsoft.Office.Interop.Excel.Range headerColumnRange = ExcelApp.get_Range("A1", "Z1");
                         headerColumnRange.Font.Bold = true;
                         headerColumnRange.Font.Color = 0xFF0000;
         
                         for (int i = 1; i < dgv.Rows.Count; i++)
                         {
                             //DataGridViewRow row = dataGridView1.Rows[i];
                             for (int j = 0; j < dgv.ColumnCount; j++)
                             {
                                 ExcelApp.Cells[i + 1, j + 1] = dgv.Rows[i - 1].Cells[j].Value.ToString();
                             }
                         }
                         ExcelApp.ActiveWorkbook.SaveCopyAs(path);
                         ExcelApp.ActiveWorkbook.Saved = true;
                         ExcelApp.Quit();
                     }
                     catch { }
                 }
