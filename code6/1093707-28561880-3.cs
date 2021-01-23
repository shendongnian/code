    public ActionResult Save(DeviceViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // save to db
            return RedirectToAction("Index");
        }
        return View("Index", viewModel);
    }
