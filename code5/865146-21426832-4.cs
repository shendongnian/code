    [HttpPost]
    public ActionResult Index(StatementViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // save the model
        }
        return View(viewModel);
    }
