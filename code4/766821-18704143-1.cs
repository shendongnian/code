    public ActionResult Create()
    {
    	var model = new SubjectModel();
    	PopulateSubjectList(model);
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult Create(SubjectModel model)
    {
    	if (ModelState.IsValid)
    	{
    		// Save item..
    	}
    	// Something went wrong.
    	PopulateSubjectList(model);
    	return View(model);
    }
    private void PopulateSubjectList(SubjectModel model)
    {
    	if (MemoryCache.Default.Contains("SubjectList"))
    	{
    		// The SubjectList already exists in the cache,
    		model.Subjects = (List<Subject>)MemoryCache.Default.Get("SubjectList");
    	}
    	else
    	{
    		// The select list does not yet exists in the cache, fetch items from the data store.
    		List<Subject> selectList = _db.Subjects.ToList();
    		
    		// Cache the list in memory for 15 minutes.
    		MemoryCache.Default.Add("SubjectList", selectList, DateTime.Now.AddMinutes(15));
    		model.Subjects = selectList;
    	}
    }
