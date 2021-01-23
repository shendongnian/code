    [Authorize(Roles = "Customer")]
    public ActionResult CreateNewUserAccount()
    {
        var model = new ServiceRequest();
        return View(model);
    }
