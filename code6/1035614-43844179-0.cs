    public PartialViewResult GetAdminMenu()
    {
        var model = new AdminMenuViewModel();
    
        return PartialView(model);
    }
