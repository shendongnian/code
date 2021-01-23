    [HttpPost]
    public ActionResult Register(Registration signingUp)
    {
        if (!ModelState.IsValid)
            return View(signingUp);
        // Model is valid, work with it... 
    }
