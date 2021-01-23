    [HttpPost]
    public ActionResult Save(UserEditModel model) {
    try {
         ViewBag.Field1 = model.Field1;
         ViewBag.Field2 = model.Field2;
         .....
        repository.SaveUser(model.CopyTo());
    }
    catch (InvalidOperationException ex) {
        // Doing this to just display it at the top of the page as it is not property-specific.
        TempData["UserError"] = ex.Message;
        // Doing this to maintain the "Edit/id" URL.
        return RedirectToAction("Edit", "Users", new { id = model.Id });
    }
    // Want to keep the URL on the Index page as "Users", instead of "Users/Save".
    return RedirectToAction("Index", "Users", new { page = model.Page });}
