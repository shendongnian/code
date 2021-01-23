    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        // Hook into the workbook open event
        this.Application.WorkbookOpen += new AppEvents_WorkbookOpenEventHandler(WorkWithWorkbook);
    }
    private void WorkWithWorkbook(Microsoft.Office.Interop.Excel.Workbook workbook)
    {
        // Workbook has been opened. Do stuff here.
    }
