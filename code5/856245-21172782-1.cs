    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(EditViewModel editViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editViewModel);
        }
        
        // You need to reconstruct the model itself, there are faster ways but I wanted
        // to showcase the logic behind it
        // I didn't do any null check or anything to simplify
        // Load the model used from the database
        var modelEntity = _modelService.GetModel(editViewModel.ModelId);
        // You can do an InjectFrom for the other properties you need
        // with custom Injection to unflatten
        modelEntity.InjectFrom(editViewModel);
        // Load the selected warranty from the database
        var warrantyEntity = _warrantyService.GetWarranty(editViewModel.WarrantyId);
        // Update the warranty of the model with the one loaded
        modelEntity.Warranty = warrantyEntity;
        _modelService.Update(modelEntity);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }
