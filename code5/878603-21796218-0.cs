    public ActionResult YourExistingAction()
    {
        YourExistingViewModel model = new YourExistingViewModel();
        model.Tokens = db.tokens.ToList();
        return View(model);
    }
