    public ActionResult Edit (int positionId)
    {
    	// Get position from db.
    	Position position = db.Positions.Find(positionId);
    	
    	// Map it to a ViewModel.
    	PositionModel positionModel = new PositionModel
    									  {
    										Id = position.Id,
    										PersonId position.Person.Id
    									  };
    									  
    	return View(positionModel);
    }
    
    [HttpPost]
    public ActionResult Edit (Postion model)
    {
    	Guid positionId = model.Id;
        Guid personId = model.PersonId;
    }
