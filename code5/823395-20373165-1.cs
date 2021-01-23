    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Missing.Value);
    Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.ActiveSheet;
    worksheet = workbook.ActiveSheet;
    
    //app.Visible = true;
    
    //getting all the columns from datagrid
    for (int i = 1; i < dg1.Columns.Count + 1; i++)
    {
        worksheet.Cells[1, i] = dg1.Columns[i - 1].HeaderText;
    }
    //getting row collection
    for (int i = 0; i < dg1.Rows.Count - 1; i++)
    {
        for (int j = 0; j < dg1.Columns.Count; j++)
    		{
                if (dg1.Rows[i].Cells[j].Value != null)
                {
                    worksheet.Cells[i + 2, j + 1] = dg1.Rows[i].Cells[j].Value.ToString();
                }
                else
                {
                    worksheet.Cells[i + 2, j + 1] = "";
                }
    			worksheet.Columns.AutoFit();                                        
            }
    }
       
    //to make the excel sheet readonly
    ((Excel.Worksheet)app.ActiveWorkbook.Sheets[1]).EnableSelection = Excel.XlEnableSelection.xlUnlockedCells;
    ((Excel.Worksheet)app.ActiveWorkbook.Sheets[1]).Protect(Password: protectionpasswprd, AllowFormattingCells: false);
    app.ActiveWorkbook.SaveCopyAs("D:\\a.xls");
    app.ActiveWorkbook.Saved = true;
    app.Quit();
