    public ActionResult action(string email)
    {
        ModelState.Clear();
        return View(new actionlModel() { ExternalIdEmail = email, Email = "" });
    }
