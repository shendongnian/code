         Excel.Application excel;
         Excel.Workbook wb;
         Excel.Worksheet sh;
            DataTable dt=new DataTable();
            excel = new Excel.Application();
            excel.Visible = true;
            wb = excel.Workbooks.Open("File Path");
            sh = wb.Sheets.Add();
            sh.Name = "Data";
            count = 2;
            sh.Cells[count, "A"].Value2 = "Coloum Name 1";
            sh.Cells[count, "B"].Value2 = "Coloum Name 2";
            sh.Cells[count, "C"].Value2 = "Coloum Name 3";
            sh.Cells[count, "D"].Value2 = "Coloum Name 4";
            sh.Cells[count, "E"].Value2 = "Coloum Name 5";
            sh.Range["A" + count + "", "E" + count + ""].Font.Size = 12;
            sh.Range["A" + count + "", "E" + count + ""].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            sh.Range["I2"].WrapText = true;
          try
        {
            con.Open();
            da.Clear();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
            sh.Cells[count, "A"].Value2 = row["Coloum Name"].ToString();
            sh.Cells[count, "B"].Value2 = row["Coloum Name"].ToString();
            sh.Cells[count, "C"].Value2 = row["Coloum Name"].ToString();
            sh.Cells[count, "D"].Value2 = row["Coloum Name"].ToString();
            sh.Cells[count, "E"].Value2 = row["Coloum Name"].ToString();
            }
            wb.SaveAs("File Path" + "File Nmae" + ".xls");
            excel.Workbooks.Close();
            excel.Quit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            con.Close();
        }
