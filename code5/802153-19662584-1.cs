    public ActionResult EditPage(Int32? id)
    {
    	MyViewModel testViewModel = new MyViewModel
    									{
    										Subs = GetSubsDict();
    									}
    	return View(testViewModel);
    }
