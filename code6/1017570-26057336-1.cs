    [HttpGet]
    public ActionResult Edit(int? entryId)
    {
        var customerViewModel = new EditEntryViewModel();
        if (entryId.HasValue)
        {
            Entry customer = _db.Entries.SingleOrDefault(x => x.Id == entryId.Value);
            customerViewModel.Title = customer.Title;
            customerViewModel.Username = customer.Username;
            customerViewModel.Password = customer.Password;
            customerViewModel.Url = customer.Url;
            customerViewModel.Description = customer.Description;
        }
        return View(customerViewModel);
    }
