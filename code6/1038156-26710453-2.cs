        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlBook = xlApp.Workbooks.Open(@"PATH_TO_EXCEL_FILE");
        Excel.Worksheet worksheet = xlBook.Worksheets[1];
        Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;
        if (selection != null)
        {
            Microsoft.Office.Tools.Excel.Controls.Button button =
                new Microsoft.Office.Tools.Excel.Controls.Button();
            worksheet.Controls.AddControl(button, selection, "Button");
        }
