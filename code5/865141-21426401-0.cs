    [HttpPost]
    public ActionResult SaveStatement(User currentUser, VMWrapper wrapper)
    {
        IVM model = SaveModel(currentUser, wrapper.Statement);
        if (model == null)
            return RedirectToAction("List");
        return View(wrapper.ViewName, model);
    }
