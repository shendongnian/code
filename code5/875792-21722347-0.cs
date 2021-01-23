    Excel.Application exc = new Excel.Application();
        if (exc == null)
        {
            Console.WriteLine("ERROR: EXCEL couldn't be started!");
        }
        Workbooks workbooks = exc.Workbooks;
        Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Sheets sheets = workbook.Worksheets;
        Worksheet worksheet = (Worksheet)sheets.get_Item(1);
        
        if (worksheet == null)
        {
            Console.WriteLine("ERROR: worksheet == null");
        }      
        Excel.Range range = worksheet.UsedRange;
        Excel.Range currentFind; 
        currentFind = range.Cells.Find(txtFind.Text.ToString(), Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole,
                        Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, false, false);
        if (currentFind != null)
        {
            MessageBox.Show("found");
        }
        else
        {
            MessageBox.Show("not found");
        }
