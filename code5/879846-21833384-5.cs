    public ActionResult Index()
    {    	
    	    var items = new List<SelectItem>();
    	    // These items would be set from your db
			var items = new List<SelectItem>();
			items.Add(new SelectItem { Id = 1, Name = "1" });
			items.Add(new SelectItem { Id = 2, Name = "2" });
			
			var selectedItems = new List<SelectItem>();
			selectedItems.Add(new SelectItem { Id = 1, Name = "1" });
			var model = new ExtrnlSubsModel();
			// project the selected indexs to an array of ints
			int[] selectedItemsArray = selectedItems.Select(s => s.Id).ToArray();
			model.ExtForumIds = selectedItemsArray;
			model.AvailableForums = new MultiSelectList(items, "ID", "Name", selectedItemsArray);
    
    	return View(model);
    }
