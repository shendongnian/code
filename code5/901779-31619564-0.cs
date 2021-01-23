    ExcelUtil.ActivateWorksheet("Sheet1");
    currentWorksheet.Activate();
    public static void ActivateWorksheet(string strWorksheetName)
        {
            bool found = false;
            foreach (Excel.Worksheet sheet in Globals.ThisAddIn.Application.Worksheets)
            {
                if (sheet.Name.ToLower() == strWorksheetName.ToLower())
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                Globals.ThisAddIn.AddNewWorksheet(strWorksheetName);
            ((Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets[strWorksheetName]).Activate();
        }
