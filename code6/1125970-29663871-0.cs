    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Group([Bind(Include = "Id,Name,Order,Include,Items")] ClaimGroupViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            ClaimGroup itemToSave = _repository.Get<ClaimGroup>(viewModel.Id);
            itemToSave.Include = viewModel.Include;
            itemToSave.Name = viewModel.Name;
            itemToSave.Order = viewModel.Order;
            itemToSave.Items.Clear();// This needs to be done, otherwise it will try and load the list from the DB again.                
            itemToSave.Items = (from i in viewModel.Items
                                where !string.IsNullOrEmpty(i.ClaimValue)
                                select new ClaimGroupItem
                                {
                                    ClaimValue = i.ClaimValue,
                                    MenuItemId = i.MenuItemId,
                                })
                    .ToList();
            _repository.Update<ClaimGroup>(itemToSave);
            return RedirectToAction("Groups", new { updated = true });
        }
        return View(viewModel);
    }
