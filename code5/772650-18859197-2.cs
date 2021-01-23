    [HttpPost]
    public ActionResult Update(AccountModel newInfo)
    {
        validateUserInfo(newInfo);
        if (ModelState.IsValid)
        {
            newInfo.updateToDatabase();
            TempData["newInfo"] = newInfo;       
            return RedirectToAction("Main");
        }
        return View(newInfo);
    }
    [HttpGet]
    public ActionResult Main()
    {
        var model = (TempData["newInfo"] as AccountModel) ?? new AccountModel();//or some other way to populate the model when it'not redirected from Update method.
        return View("View", model);
    }
