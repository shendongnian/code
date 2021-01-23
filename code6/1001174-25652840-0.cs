    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application ExcelApp = new Excel.Application();
    Excel.Workbook ExcelWorkBook = null;
    Excel.Worksheet ExcelWorkSheet = null;
    
    ExcelApp.Visible = true;
    ExcelWorkBook = ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
    
    List<string> SheetNames = new List<string>() 
        { "Sheet1", "Sheet2", "Sheet3", "Sheet4", "Sheet5", "Sheet6", "Sheet7"};
    
    string [] headers = new string [] 
        { "Field 1", "Field 2", "Field 3", "Field 4", "Field 5" };
    
    for (int i = 0; i < SheetNames.Count; i++)
        ExcelWorkBook.Worksheets.Add(); //Adding New sheet in Excel Workbook
    
    for (int k = 0; k < SheetNames.Count; k++ )
    {
        int r = 1; // Initialize Excel Row Start Position  = 1
    
        ExcelWorkSheet = ExcelWorkBook.Worksheets[k + 1];
        //Writing Columns Name in Excel Sheet
        for (int col = 1; col < headers.Length + 1; col++)
            ExcelWorkSheet.Cells[r, col] = headers[col - 1];
        r++;
        switch (k)
        {
            case 0:
                foreach (var kvp in Sheet1)
                {
                    ExcelWorkSheet.Cells[r, 1] = kvp.Value.Field1;
                    ExcelWorkSheet.Cells[r, 2] = kvp.Value.Field2;
                    ExcelWorkSheet.Cells[r, 3] = kvp.Value.Field3;
                    ExcelWorkSheet.Cells[r, 4] = kvp.Value.Field4;
                    ExcelWorkSheet.Cells[r, 5] = kvp.Value.Field5;
                    r++;
                }
                break;
    
        }
        ExcelWorkSheet.Name = SheetNames[k];//Renaming the ExcelSheets
    }
    
    //Activate the first worksheet by default.
    ((Excel.Worksheet)ExcelApp.ActiveWorkbook.Sheets[1]).Activate();
    
    //Save As the excel file.
    ExcelApp.ActiveWorkbook.SaveCopyAs(@"out_My_Book1.xls");
