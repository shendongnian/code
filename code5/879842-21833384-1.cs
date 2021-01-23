    public ActionResult Index()
    {
    	ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
    	var items = new List<SelectItem>();
    	items.Add(new SelectItem { Id = 1, Name = "1" });
    	items.Add(new SelectItem { Id = 2, Name = "2" });
    	
    	var selectedItems = new List<SelectItem>();
    	selectedItems.Add(new SelectItem { Id = 1, Name = "1" });
    	
    	var model = new ExtrnlSubsModel();
    	model.ExtForumIds = selectedItems.Select(s => s.Id).ToArray();
    	model.AvailableForums = new MultiSelectList(items, "ID", "Name", selectedItems.Select(s => s.Id).ToArray());
    
    	return View(model);
    }
