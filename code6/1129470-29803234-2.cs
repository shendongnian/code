        using Excel = Microsoft.Office.Interop.Excel;
        using Microsoft.Office.Interop.Excel;
        using System.Reflection;
        public void Export_DataGridView_To_Excel(DataGridView DGV, string filename)
        {
            string[] Alphabit = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                  "N", "O","P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string Range_Letter = Alphabit[DGV.Columns.Count];
            string Range_Row = (DGV.Rows.Count + 1).ToString();
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            Excel.Application oApp;
            Excel.Worksheet oSheet;
            Excel.Workbook oBook;
            oApp = new Excel.Application();
            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);
            for (int x = 0; x < DGV.Columns.Count; x++)
            {
                // creating Columns :
                oSheet.Cells[1, x + 2] = DGV.Columns[x].HeaderText;
            }
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                for (int j = 0; j < DGV.Rows.Count; j++)
                {
                    // creating rows :
                    oSheet.Cells[j + 2, i + 2] = DGV.Rows[j].Cells[i].Value;
                }
            }
            //Add some formatting
            Range rng1 = oSheet.get_Range("B1", Range_Letter + "1");
            rng1.Font.Size = 14;
            rng1.Font.Bold = true;
            rng1.Cells.Borders.LineStyle = XlLineStyle.xlDouble;
            rng1.Cells.Borders.Color = System.Drawing.Color.DeepSkyBlue;
            rng1.Font.Color = System.Drawing.Color.Black;
            rng1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng1.Interior.Color = System.Drawing.Color.LightGray;
            Range rng2 = oSheet.get_Range("B2", Range_Letter + Range_Row);
            rng2.WrapText = false;
            rng2.Font.Size = 12;
            rng2.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
            rng2.Cells.Borders.Color = System.Drawing.Color.DeepSkyBlue;
            rng2.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng2.Interior.Color = System.Drawing.Color.Azure;
            rng2.EntireColumn.AutoFit();
            rng2.EntireRow.AutoFit();
            //Add a header row
            oSheet.get_Range("B1", Range_Letter + "2").EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
            oSheet.Cells[1, 3] = "List of : list title ";
            Range rng3 = oSheet.get_Range("B1", Range_Letter + "2");
            rng3.Merge(Missing.Value);
            rng3.Font.Size = 16;
            rng3.Font.Color = System.Drawing.Color.Blue;
            rng3.Font.Bold = true;
            rng3.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng3.Interior.Color = System.Drawing.Color.LightSkyBlue;
            oBook.SaveAs(filename);
            oBook.Close();
            oApp.Quit();
         // NASSIM LOUCHANI
        }
        private void Button_Click(object sender, EventArgs e)
        {
          SaveFileDialog sfd = new SaveFileDialog();
           
          sfd.Title = "Export To Excel";
          sfd.Filter = "To Excel (Xlsx)|*.xlsx";
          sfd.FileName = "your document name";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                 AED.Export_DataGridView_To_Excel(dataGridView,sfd.FileName);
            }
        }
