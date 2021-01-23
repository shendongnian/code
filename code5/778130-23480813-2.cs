    public ActionResult Edit(int id = 0)
    {
        var query = _repo.GetByID(id);
        string selected = query.tEntityType.entityTypeID.ToString();
    
        DropDownViewModel entityType = new DropDownViewModel
        {
            Items = _repo.GetEditList<tEntityType>("entityType", "entityTypeID", selected)
        };
    
        OrganisationEditViewModel a = GetUpdate(id);
        a.entityTypeID = entityType;
    
        if (a == null)
        {
            return HttpNotFound();
        }
        return View(a);
    }
