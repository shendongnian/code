    public ActionResult ViewModelExtension(int id)
    {
    	var viewModel = new tbl1join();
    	
    	viewModel.HEADER_RECORD = db.HEADER_RECORD.Where(h => h.id == id).SingleOrDefault;
    	viewModel.HEADER_EXTENSION_RECORD = db.HEADER_EXTENSION_RECORD.Where(h => h.id == id).SingleOrDefault;
    	
    	return View(viewModel);
    }
