       public void ExportToExecl(DataGridView dg, string filename)
        {
             // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            try
            {
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                // changing the name of active sheet
                worksheet.Name = "Exported from History Parsing";
                // storing header part in Excel
                for (int i = 1; i < dg.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dg.Columns[i - 1].HeaderText;
                    worksheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                }
                // storing Each row and column value to excel sheet
                for (int i = 0; i < dg.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dg.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                    }
                }
                // save the application
                workbook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("Your excel file was created successfully");
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                app.Quit();
                workbook = null;
                app = null;
            }
        }
