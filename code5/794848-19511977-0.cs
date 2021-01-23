    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(DeviceEditViewModel editViewModel)
    {
        if (ModelState.IsValid)
        {
            //non-working: Device device = editViewmodel.env;
            Device device = db.Devices.Single(x => x.Id == editViewModel.dev.Id); /*working*/
            if (editViewModel.SelectedCategory != null)
            {
               device.Category = db.Categories.Where(x => x.ID == editViewModel.SelectedCategory).Select(x => x).Single();
            }
            db.Entry(device).State = EntityState.Modified;
            db.Devices.AddOrUpdate(device);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            return View(editViewModel);
    }
