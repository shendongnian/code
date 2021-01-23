        Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;
        if (selection != null)
        {
            Microsoft.Office.Tools.Excel.Controls.Button button =
                new Microsoft.Office.Tools.Excel.Controls.Button();
            worksheet.Controls.AddControl(button, selection, "Button");
        }
