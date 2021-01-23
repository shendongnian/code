    Excel.Application excel = new Excel.Application();
    Excel.Workbook workbook = excel.Workbooks.Open("filelocation");
    foreach (Excel.Worksheet ws in workbook.Worksheets)
    {
        ws.Activate();
        ws.Application.ActiveWindow.SplitColumn = 6;
        ws.Application.ActiveWindow.SplitRow = 1;
        ws.Application.ActiveWindow.FreezePanes = true;
    }
    excel.Visible = true; 
