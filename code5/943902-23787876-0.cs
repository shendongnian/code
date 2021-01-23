    public ActionResult GetIssueList(string code)
    {
        return Json(new ProjectManager()
            .SelectAllProjects()
            .Select(proj => proj as Project)
            .Where(proj => proj.CustomerCode == code)
            .ToList();
    }
