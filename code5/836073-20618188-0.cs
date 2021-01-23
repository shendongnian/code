    public ActionResult Index()
	{
		var localDb = new List<string>{"a", "b"};
		var wcf = new List<string>{"b","c"};
		var all = new HashSet<String>(localDb);
		all.UnionWith(wcf);
		var viewModel = new List<CategoryIndex>
		{
			new CategoryIndex
				{
					Title = "Avaliable Product Categories",
					CategoryNames = all.AsEnumerable()
				}
		};
		return View(viewModel);
	}
