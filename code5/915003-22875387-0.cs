    private void export_btn_Click(object sender, EventArgs e)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp =
                          new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;
    
                int i = 0;
                int j = 0;
    
                //create object of excel
                ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;
                //export header
                for (i = 1; i <= this.dataGridView1.Columns.Count; i++)
                {
                    ExcelSheet.Cells[1, i] = this.dataGridView1.Columns[i - 1].HeaderText;
                }
    
                //export data
                for (i = 1; i <= this.dataGridView1.RowCount; i++)
                {
                    for (j = 1; j <= dataGridView1.Columns.Count; j++)
                    {
                        ExcelSheet.Cells[i + 1, j] = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                    }
                }
    
                ExcelApp.Visible = true;
    
                //set font Khmer OS System to data range
                Microsoft.Office.Interop.Excel.Range myRange = ExcelSheet.get_Range(
                                          ExcelSheet.Cells[1, 1],
                                          ExcelSheet.Cells[this.dataGridView1.RowCount + 1,
                                          this.dataGridView1.Columns.Count]);
                Microsoft.Office.Interop.Excel.Font x = myRange.Font;
                x.Name = "Arial";
                x.Size = 10;
    
                //set bold font to column header
                myRange = ExcelSheet.get_Range(ExcelSheet.Cells[1, 1],
                                         ExcelSheet.Cells[1, this.dataGridView1.Columns.Count]);
                x = myRange.Font;
                x.Bold = true;
                //autofit all columns
                myRange.EntireColumn.AutoFit();
    
    
                ExcelApp.ActiveWorkbook.SaveCopyAs("E:\\reports.xlsx");
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                MessageBox.Show("Excel file created,you can find the file E:\\reports.xlsx");
                //
                ExcelSheet = null;
                ExcelBook = null;
                ExcelApp = null;            
            }
