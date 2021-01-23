    public ActionResult Edit(int? id)
    {
        //check the id
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        //get the model and make sure the object is populated
        var model = _modelService.GetModel(id.Value);
        if (model == null)
        {
            return HttpNotFound();
        }
        //pass our entity (db) model to our view model
        var editViewModel = new EditViewModel();
        editViewModel.InjectFrom(model);
        
        // You could instead create a custom injection like FlatLoopValueInjection
        // That would flatten and remove duplicates from 
        // Model.Warranty.WarrantyId to ViewModel.WarrantyId
        editViewModel.WarrantyId = model.Warranty.Id;
        //warranty select list
        editViewModel.WarrantySelectListItems = WarrantySelectList(editViewModel.WarrantyId);
        return View(editViewModel);
    }
