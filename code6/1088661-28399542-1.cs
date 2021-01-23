    // GET: Shelves
    public async Task<IActionResult> Index()
    {
	    var model = new IndexViewModel();
		model.Shelves = db.Shelves
			.Select(s => new ShelveModel()
			{
				Name = s.Name,
				BookCount = s.Books.Count()
			})
			.ToListAsync();
	
        return View(model);
    }
