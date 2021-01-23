    private void ExportToExcel(DataTable Tbl, string ExcelFilePath = null)
    {
        try
        {
            if (Tbl == null || Tbl.Columns.Count == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            // load excel, and create a new workbook
            Excel.Application excelApp = new Excel.Application();
            //Excel.Workbook ExcelBookServices = excelApp.Workbooks.Add();
            excelApp.Workbooks.Add();
            // single worksheet
            Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;
            // column headings
            for (int i = 0; i < Tbl.Columns.Count; i++)
            {
                workSheet.Cells[1, (i + 1)] = Tbl.Columns[i].ColumnName;
            }
            // rows
            for (int i = 0; i < Tbl.Rows.Count; i++)
            {
                // to do: format datetime values before printing
                for (int j = 0; j < Tbl.Columns.Count; j++)
                {
                    workSheet.Cells[(i + 2), (j + 1)] = Tbl.Rows[i][j];
                }
            }
            workSheet.Columns.AutoFit();
            //workSheet.Columns.Style = "Output";
            //Excel.Range cell = ((Excel.Range)workSheet.Cells[Tbl.Rows.Count, Tbl.Columns.Count]);
            // check fielpath
            if (ExcelFilePath != null && ExcelFilePath != "")
            {
                try
                {
                    workSheet.SaveAs(ExcelFilePath);
                    excelApp.Quit();
                    //File Saved Message
                }
                catch (Exception ex)
                {
                    //ExportToExcel: Excel file could not be saved! Check filepath Message
                }
            }
            else // no filepath is given
            {
                excelApp.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //Error in creating the Excel file
            ScriptManager.RegisterStartupScript(this, GetType(), "Message", "ExportToExcel: \n" + ex.Message, true);
        }
    }
