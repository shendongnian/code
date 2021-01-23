    private void Button_Click(object sender, RibbonControlEventArgs e)
    {
        Worksheet worksheet = Globals.Factory.GetVstoObject(
           Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);
        string buttonName = "MyButton";
        if (((RibbonCheckBox)sender).Checked)
        {
            Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;
            if (selection != null)
            {
                Microsoft.Office.Tools.Excel.Controls.Button button =
                   new Microsoft.Office.Tools.Excel.Controls.Button();
                worksheet.Controls.AddControl(button, selection, buttonName);
            }
        }
        else
        {
            worksheet.Controls.Remove(buttonName);
        }
    }
