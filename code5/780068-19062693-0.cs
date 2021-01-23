    ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                IWorkbook workbook = application.Workbooks.Create(1); //We are using single workbook
                IWorksheet sheet = workbook.Worksheets[0]; //In this case we are exporting to single ExcelSheet so we marked Worksheets as 0 
                for (int i = 0; i < grid.Model.RowCount; i++)
                {
                    //Setting Excel cell height based on Grid Cell height
                    sheet.SetRowHeightInPixels(i + 1, set heigth here);
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        int width = Convert.ToInt32(ColumnWidths[j]); //Getting Grid Cell column width
                        sheet.SetColumnWidthInPixels(j + 1, width); //Setting Width for Excel cell
                        sheet.Range[i + 1, j + 1].Text = dt value here;
                    }
                }
