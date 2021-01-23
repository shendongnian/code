    public ActionResult EditPage(MyViewModel model)
    {
    	model.Subs = GetSubsDict();
        return View(model);
    }
