            for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
            {
                if (i == 1)
                {
                    ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                }
                else
                    ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
            }
        }
        ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Users\\Mor Shivek\\Desktop\\test.xls");
        ExcelApp.ActiveWorkbook.Saved = true;
        ExcelApp.Quit();}
