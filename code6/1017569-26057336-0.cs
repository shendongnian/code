    [HttpGet]
    public ActionResult Edit(int? entryId)
    {
        Entry customer = _db.Entries.Single(x => x.Id == entryId);
        var customerViewModel = new EditEntryViewModel();
        customerViewModel.Title = customer.Title;
        customerViewModel.Username = customer.Username;
        customerViewModel.Password = customer.Password;
        customerViewModel.Url = customer.Url;
        customerViewModel.Description = customer.Description;
        return View(customerViewModel);
     }
