    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.SheetActivate +=
        new Excel.AppEvents_SheetActivateEventHandler(
        Application_SheetActivate);
    }
    void Application_SheetActivate(object Sh)
    {
        // Your code here to check if the copy is a duplicate or not
    }
