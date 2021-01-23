    public ActionResult Create(int Id = 0)
    {
    	MyObjectModel resultModel = new MyObjectModel();
    	
    	var ObjectResultList = _system.GetAllObjects(Id);
    	var ObjectSelectList = new SelectList(ObjectResultList, "id", "Name");
    	ViewBag.ObjectList = ObjectSelectList;
    
    	return View(resultModel);
    }
