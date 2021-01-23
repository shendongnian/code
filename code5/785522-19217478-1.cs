    [HttpPost]
    public ActionResult Edit(HouseholdAddViewModel model, int id)
    {
        model.entityTypeID = _repo.GetEntityType();
        if (ModelState.IsValid)
        {
            var h = _repo.GetHousehold(id);
            h.InjectFrom(model);
            h.entityID = id;      
            //...
        }
    }
