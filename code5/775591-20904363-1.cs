    public ActionResult action(string email)
    {
        ModelState.Remove("email");
        return View(new actionlModel() { ExternalIdEmail = email, Email = "" });
    }
