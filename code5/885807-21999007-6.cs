    [Authorize(Roles = "Customer")]
    public ActionResult CreateNewUserAccount()
    {
        var model = new ServiceRequest();
        model.Log = new Log();
        return View(model);
    }
