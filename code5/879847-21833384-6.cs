    [HttpPost]
    public ActionResult Index(ExtrnlSubsModel model)
    {
    	var selectedItems = model.ExtForumIds;
    	return View(model);
    }
