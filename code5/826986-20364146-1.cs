	public ActionResult Index()
	{
		Test model = new Test()
		{
			Id = 1,
			Items = new List<Item>()
			{
				new Item {Id = 1, Selected = false, Description = "Item1"},
				new Item {Id = 2, Selected = false, Description = "Item2"},
				new Item {Id = 3, Selected = false, Description = "Item3"}
			}
		};
		return View(model);
	}
	
