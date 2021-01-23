    static Dictionary<WeakReference, CustomTaskPane> _createdPanes = new Dictionary<WeakReference, CustomTaskPane>();
    void Application_WorkbookActivate(Excel.Workbook Wb)
    {
        var taskPane = (_createdPanes.Where(kvp=>kvp.Key.Target==Wb).Select(kvp=>kvp.Value).FirstOrDefault());
        if(taskPane == null)
        {
            UserControl view = ...create UI;
            taskPane = this.CustomTaskPanes.Add(view, "My pane for workbook "+ Wb.Name);
            _createdPanes[new WeakReference(Wb)] = taskPane;
        }
    }
