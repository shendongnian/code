    public ActionResult Create()
    {
        var model = new EmployeeDetailModel();
        model.Roles = new List<WebApplication2.Entities.Role>();
        return View(model);
    }
