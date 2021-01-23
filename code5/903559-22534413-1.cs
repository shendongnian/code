    public ActionResult SidebarTopics(/* route params */)
    {
        var model = new ProjectDetailsModel();
        return PartialView("_SiderbarTopics", model);
    }
