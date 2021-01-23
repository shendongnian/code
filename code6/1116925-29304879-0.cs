    public async Task<ActionResult> Edit(EditVehicleViewModel vehiclViewModel)
    {
        if (ModelState.IsValid)
        {
             // I am guessing the VINNumber is the identifier
            Vehicle vModel = db.Vehicle.FirstOrDefault(v => v.VINNumber == vehiclViewModel.VINNumber);
            // Mapping here
            vModel.LicenceNumber = vehiclViewModel.LicenceNumber;
            vModel.Year = vehiclViewModel.Year;
            vModel.Color = vehiclViewModel.Color;
            vModel.VINNumber = vehiclViewModel.VINNumber
            vModel.ImageUrl = vehiclViewModel.ImageUrl;
            db.Entry(vModel).State = vModel.ID == 0 ? EntityState.Added : EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(vehiclViewModel);
    }
