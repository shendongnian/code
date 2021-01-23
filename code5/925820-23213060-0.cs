     public static void ExportToExcelOnece(DataSet dsExcel, string ExcelFilePath)
        {
            if (dsExcel == null || dsExcel.Tables.Count == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel.Worksheet newWorksheet;
            Excel.Worksheet objSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.Sheets["Sheet1"];
            for (int m = 0; m <= dsExcel.Tables.Count - 1; m++)
            {
                newWorksheet = (Excel.Worksheet)excelApp.Worksheets.Add(objSheet, Missing.Value, Missing.Value, Missing.Value);
                newWorksheet.Name = dsExcel.Tables[m].TableName;
                // column headings
                for (int i = 0; i < dsExcel.Tables[m].Columns.Count; i++)
                {
                    newWorksheet.Cells[1, (i + 1)] = dsExcel.Tables[m].Columns[i].ColumnName;
                }
                // rows
                for (int i = 0; i < dsExcel.Tables[m].Rows.Count; i++)
                {
                    for (int j = 0; j < dsExcel.Tables[m].Columns.Count; j++)
                    {
                        newWorksheet.Cells[(i + 2), (j + 1)] = dsExcel.Tables[m].Rows[i][j];
                    }
                }
            }
            ((Excel.Worksheet)excelApp.ActiveWorkbook.Sheets[1]).Activate();
            objSheet.Delete();
            objSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.Sheets["Sheet2"];
            objSheet.Delete();
            objSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.Sheets["Sheet3"];
            objSheet.Delete();
            // check fielpath
            if (ExcelFilePath != null && ExcelFilePath != "")
            {
                try
                {
                    excelApp.ActiveWorkbook.SaveAs(ExcelFilePath);
                    excelApp.Quit();
                    MessageBox.Show("Excel file saved!");
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        + ex.Message);
                }
            }
            else    // no filepath is given
            {
                excelApp.Visible = true;
            }
            //Quit the Application.
            excelApp.Quit();
        }
