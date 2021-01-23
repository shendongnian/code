    private Workbook GetWorkbooksByProject(int projectId)
    {
        WorkBookDataManager dataManager = new WorkBookDataManager();
        var workbookColl = dataManager.GetWorkBooksById(null, projectId, null);   
        return workbookColl;
    }
    public JsonResult GetWorkbooks(int projectId)
    {
        var model = GetWorkbooksByProject(projectId);
        return Json(model, JsonRequestBehavior.AllowGet);
    }
    public ActionResult WorkbooksList(string term, int projectId = -1)
    {
        if (this.SelectedProject != projectId)
        {
            try
            {
                this.WorkbookColl = GetWorkbooksByProject(projectId);
                this.SelectedProject = projectId;
            }
            catch (Exception exc)
            {
                log.Error("Could not load projects", exc);
            }
        }
        return this.View("_Workbook", this.WorkbookColl);
    }
