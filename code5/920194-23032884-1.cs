    protected void insertBTN(object sender, EventArgs e)
    {string conString = @"Data Source =XXXX; Initial Catalog=XXXX;     Persist Security Info=True;User ID=XXXX; Password=XXXX";SqlConnection sqlCon     = new SqlConnection(conString);
    sqlCon.Open();
               
     SqlDataAdapter da = new SqlDataAdapter("SELECT * from InjuryScenario", sqlCon);
     System.Data.DataTable dtMainSQLData = new System.Data.DataTable();
     da.Fill(dtMainSQLData);
     DataColumnCollection dcCollection = dtMainSQLData.Columns;
        // Export Data into EXCEL Sheet
     Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new                                            
     Microsoft.Office.Interop.Excel.ApplicationClass();
        ExcelApp.Application.Workbooks.Add(Type.Missing);
        // ExcelApp.Cells.CopyFromRecordset(objRS);
        for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
        {
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
