    private Outlook.Application _thisApp;
    private Outlook.Inspectors _inspectors;
    // Function in ThisAddin.cs 
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        _thisApp = this.Application;
        _inspectors = _thisApp.Inspectors;
        _inspectors.NewInspector +=
        new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
    }
