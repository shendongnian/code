    [HttpPost]
    public ActionResult Save(YourViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // Save to db
        }
        return PartialView("_PartialViewName", viewModel);
    }
