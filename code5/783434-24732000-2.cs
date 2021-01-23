    static Dictionary<int, CustomTaskPane> _createdPanes = new Dictionary<int, CustomTaskPane>();
    void Application_WorkbookActivate(Excel.Workbook Wb)
    {
        var taskPane = (_createdPanes.Where(kvp=>kvp.Key==Globals.ThisAddIn.Application.Hwnd).Select(kvp=>kvp.Value).FirstOrDefault());
        if(taskPane == null)
        {
            UserControl view = ...create UI;
            taskPane = this.CustomTaskPanes.Add(view, "My task pane");
            _createdPanes[Globals.ThisAddIn.Application.Hwnd] = taskPane;
        }
    }
